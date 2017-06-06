using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace RentOfWagons
{
    public partial class UpdateRent : Form
    {
        private readonly Operation _originalRent;
        private readonly Wagon _wagon;
        public UpdateRent(Operation original)
        {
            InitializeComponent();
            _originalRent = original;
            _wagon = UnitOfWork.Instance.OperationRepository.GetWagonById(_originalRent.WagonID);
        }

        private void UpdateRent_Load(object sender, EventArgs e)
        {
            initForm();
            initDateTimePickers();
            ActiveControl = dateTimePickerStart;
        }

        private void initDateTimePickers()
        {
            initDateTimePickerStart();
            initDateTimePickerEnd();

            if (dateTimePickerStart.Enabled) //нужно следить чтобы дата начала аренды была всегда <= даты окончания
            {
                dateTimePickerStart.CloseUp += new EventHandler(updateFormForSelectedStart);
                dateTimePickerEnd.CloseUp += new EventHandler(updateFormForSelectedEnd);
            }
        }
        private void initForm()
        {
            //нельзя редактировать поля: вагон, номер контракта, продавец, покупатель
            labelWagonNumber.Text += _wagon.Number.ToString("D8");
            labelContractNumber.Text += _originalRent.ContractNumber;
            textBoxTransmitter.ReadOnly = true;
            textBoxReceiver.ReadOnly = true;
            if (_originalRent.TransmitterContractorID.HasValue)
                textBoxTransmitter.Text = UnitOfWork.Instance.OperationRepository.GetContractorById(_originalRent.TransmitterContractorID.Value).Name;
            textBoxReceiver.Text = UnitOfWork.Instance.OperationRepository.GetContractorById(_originalRent.ReceiverContractorID).Name;

            comboBoxOperationType.DisplayMember = "Name";
            comboBoxOperationType.DataSource = UnitOfWork.Instance.OperationRepository.GetAllRentTypes();
        }

        private void initDateTimePickerStart()
        {
            //нельзя редактировать дату начала аренды, если срок действия этой аренды уже начался
            if (_originalRent.StartDate < DateTime.Today)
            {
                dateTimePickerStart.Enabled = false;
            }
            else//если срок действия аренды начинается сегодня или позже
            {
                //Определяем минимально возможную дату:

                //срок действия аренды начинается не раньше, чем истечет срок аренды того же уровня, которая начинает действовать раньше выбранной аренды внутри общей родительской операции
                List<Operation> sameLevelRentsInCommonParent = UnitOfWork.Instance.OperationRepository.GetSameLevelRentsInCommonParent(_originalRent);

                Operation parentRent = UnitOfWork.Instance.OperationRepository.GetParentRentForSpecifiedRent(_originalRent);
                Operation parentSale = UnitOfWork.Instance.OperationRepository.GetParentSaleForSpecifiedRent(_originalRent);

                Operation prevSameLevelRent = sameLevelRentsInCommonParent.Where(x => x.EndDate < _originalRent.StartDate).OrderByDescending(x => x.EndDate).FirstOrDefault();
                if (prevSameLevelRent != null)
                {
                    dateTimePickerStart.MinDate = prevSameLevelRent.EndDate.Value.AddDays(1);
                }
                else //если нет предшествующих аренд того же уровня внутри общей родительской операции, тогда ограничением будет начало действия родителькой аренды или, если нет родительской аренды, начало действия родительской продажи
                {
                    if (parentRent != null)
                    {
                        dateTimePickerStart.MinDate = parentRent.StartDate;
                    }
                    else
                    {
                        dateTimePickerStart.MinDate = parentSale.StartDate;
                    }
                }
                dateTimePickerStart.MinDate = dateTimePickerStart.MinDate > DateTime.Today ? dateTimePickerStart.MinDate : DateTime.Today;

                //Определяем максимально возможную дату:

                //срок действия аренды начинается не позже, чем вступит в силу первая из субаренд
                List<Operation> subrents = UnitOfWork.Instance.OperationRepository.GetChildOperations(_originalRent);
                if (subrents.Any())
                {
                    dateTimePickerStart.MaxDate = subrents.OrderBy(x => x.StartDate).First().StartDate;
                }
                else //если аренда не содержит ни одной субаренды, тогда ограничением будет начало действия аренды того же уровня, которая вступает в силу после выбранной аренды внутри общей родительской операции
                {
                    Operation nextSameLevelRent = sameLevelRentsInCommonParent.Where(x => x.StartDate > _originalRent.EndDate).OrderBy(x => x.StartDate).FirstOrDefault();
                    if (nextSameLevelRent != null)
                    {
                        dateTimePickerStart.MaxDate = nextSameLevelRent.StartDate.AddDays(-1);
                    }
                    else //если нет последующих аренд того же уровня внутри общей родительской операции, тогда ограничением будет окончание действия родителькой аренды или, если нет родительской аренды, окончание действия родительской продажи (т.е. дата следующей продажи)
                    {
                        if (parentRent != null)
                        {
                            dateTimePickerStart.MaxDate = parentRent.EndDate.Value;
                        }
                        else
                        {
                            Operation nextSale = UnitOfWork.Instance.OperationRepository.GetNextSaleForSpecifiedOperation(parentSale);
                            if (nextSale != null)
                            {
                                dateTimePickerStart.MaxDate = nextSale.StartDate.AddDays(-1);
                            }
                            else //если после аренды нет операций - ограничение не ставим
                            {
                                dateTimePickerStart.MaxDate = DateTime.MaxValue;
                            }
                        }
                    }
                }
            }

            dateTimePickerStart.Value = _originalRent.StartDate;
        }

        private void initDateTimePickerEnd()
        {
            //Определяем минимально возможную дату:

            //срок действия аренды не может закончиться раньше, чем сроки действия субаренд
            List<Operation> childRents = UnitOfWork.Instance.OperationRepository.GetChildOperations(_originalRent);
            if (childRents.Any())
            {
                DateTime lastChildRentExpire = childRents.OrderByDescending(x => x.EndDate).First().EndDate.Value;
                dateTimePickerEnd.MinDate = lastChildRentExpire;
            }
            else //если у выбранной аренды нет субаренд, тогда ограничением будет минимально возможная дата начала аренды
            {
                dateTimePickerEnd.MinDate = dateTimePickerStart.MinDate;
            }

            //если срок действия аренды уже начался, то закончиться он может не раньше чем сегодня
            if (_originalRent.StartDate < DateTime.Today)
            {
                dateTimePickerEnd.MinDate = dateTimePickerEnd.MinDate < DateTime.Today ? DateTime.Today : dateTimePickerEnd.MinDate;
            }

            //Определяем максимально возможную дату:

            List<Operation> sameLevelRentsInCommonParent = UnitOfWork.Instance.OperationRepository.GetSameLevelRentsInCommonParent(_originalRent);

            Operation parentRent = UnitOfWork.Instance.OperationRepository.GetParentRentForSpecifiedRent(_originalRent);
            Operation parentSale = UnitOfWork.Instance.OperationRepository.GetParentSaleForSpecifiedRent(_originalRent);

            Operation nextSameLevelRent = sameLevelRentsInCommonParent.Where(x => x.StartDate > _originalRent.EndDate).OrderBy(x => x.StartDate).FirstOrDefault();

            //срок действия аренды заканчивается не позже, чем начинается срок аренды того же уровня, которая начинает действовать позже выбранной аренды внутри общей родительской операции
            if (nextSameLevelRent != null)
            {
                dateTimePickerEnd.MaxDate = nextSameLevelRent.StartDate.AddDays(-1);
            }
            else //если нет последующих аренд того же уровня внутри общей родительской операции, тогда ограничением будет окончание действия родителькой аренды или, если нет родительской аренды, окончание действия родительской продажи (т.е. дата следующей продажи)
            {
                if (parentRent != null)
                {
                    dateTimePickerEnd.MaxDate = parentRent.EndDate.Value;
                }
                else
                {
                    Operation nextSale = UnitOfWork.Instance.OperationRepository.GetNextSaleForSpecifiedOperation(parentSale);
                    if (nextSale != null)
                    {
                        dateTimePickerEnd.MaxDate = nextSale.StartDate.AddDays(-1);
                    }
                    else //если после аренды нет операций - ограничение не ставим
                    {
                        dateTimePickerEnd.MaxDate = DateTime.MaxValue;
                    }
                }
            }

            dateTimePickerEnd.Value = _originalRent.EndDate.Value;
        }

        private void updateFormForSelectedStart(object sender, EventArgs e)
        {
            if(dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }

        private void updateFormForSelectedEnd(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerStart.Value = dateTimePickerEnd.Value;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Operation updatedOperation = new Operation();
                updatedOperation.OperationID = _originalRent.OperationID;
                updatedOperation.WagonID = _originalRent.WagonID;
                updatedOperation.TransmitterContractorID = _originalRent.TransmitterContractorID;
                updatedOperation.TransmitterDepartmentID = _originalRent.TransmitterDepartmentID;
                updatedOperation.ReceiverContractorID = _originalRent.ReceiverContractorID;
                updatedOperation.ReceiverDepartmentID = _originalRent.ReceiverDepartmentID;
                updatedOperation.ContractNumber = _originalRent.ContractNumber;
                updatedOperation.RentLevel = _originalRent.RentLevel;

                updatedOperation.ContractDate = DateTime.Today;
                updatedOperation.TypeID = (comboBoxOperationType.SelectedItem as OperationType).TypeID;
                updatedOperation.StartDate = dateTimePickerStart.Value;
                updatedOperation.EndDate = dateTimePickerEnd.Value;

                UnitOfWork.Instance.OperationRepository.Update(updatedOperation);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
