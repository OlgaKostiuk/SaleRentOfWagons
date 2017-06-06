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
            initDateTimePickerStart();
            initDateTimePickerEnd();
            ActiveControl = dateTimePickerStart;
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

                //срок действия аренды начинается не раньше, чем истечет срок аренды того же уровня, которая начинает действовать раньше внутри общей родительской операции
                List<Operation> list = UnitOfWork.Instance.OperationRepository.GetSameLevelRentsInCommonParent(_originalRent);
                Operation prevSameLevelRent = list.Where(x => x.EndDate < _originalRent.StartDate).OrderByDescending(x => x.EndDate).FirstOrDefault();
                if(prevSameLevelRent != null)
                {
                    dateTimePickerStart.MinDate = prevSameLevelRent.EndDate.Value.AddDays(1);
                }
                else//если нет предшествующих аренд того же уровня внутри общей родительской операции, тогда ограничением будет начало действия родителькой аренды или, если нет родительской аренды, родительской продажи
                {
                    Operation parentRent = UnitOfWork.Instance.OperationRepository.GetParentRentForSpecifiedRent(_originalRent);
                    if(parentRent != null)
                    {
                        dateTimePickerStart.MinDate = parentRent.StartDate;
                    }
                    else
                    {
                        Operation parentSale = UnitOfWork.Instance.OperationRepository.GetParentSaleForSpecifiedRent(_originalRent);
                        dateTimePickerStart.MinDate = parentSale.StartDate;
                    }
                }
                dateTimePickerStart.MinDate = dateTimePickerStart.MinDate > DateTime.Today ? dateTimePickerStart.MinDate : DateTime.Today;

                //TODO
                //Определяем максимально возможную дату:

                
            }

            dateTimePickerStart.Value = _originalRent.StartDate;
        }

        //TODO
        private void initDateTimePickerEnd()
        {


            dateTimePickerEnd.Value = _originalRent.EndDate.Value;
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
