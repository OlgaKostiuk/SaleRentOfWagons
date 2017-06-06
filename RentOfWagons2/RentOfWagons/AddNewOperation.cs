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
    public partial class AddNewOperation : Form
    {
        private readonly Wagon _wagon;
        private int _rentLevel;
        private Operation baseOperationForNewRent;

        public AddNewOperation(Wagon wagon)
        {
            InitializeComponent();
            _wagon = wagon;
            comboBoxTransmitters.DisplayMember = "Name";
            comboBoxReceivers.DisplayMember = "Name";
            comboBoxTypes.DisplayMember = "Name";
        }

        private void AddNewOperation_Load(object sender, EventArgs e)
        {
            labelWagonNumber.Text += _wagon.Number.ToString("D8");

            //нельзя оформить аренду, если не было покупки, т.е. если у вагона нет владельца
            Contractor owner = UnitOfWork.Instance.OperationRepository.GetOwner(_wagon);
            if(owner == null)
            {
                radioButtonRent.Enabled = false;
            }

            initFormForSale();

        }

        private void initFormForSale()
        {
            comboBoxTypes.DataSource = UnitOfWork.Instance.OperationRepository.GetAllSaleTypes();
            dateTimePickerEnd.Enabled = false;
            dateTimePickerStart.CloseUp -= new EventHandler(updateFormForSelectedStart);
            dateTimePickerEnd.CloseUp -= new EventHandler(updateFormForSelectedEnd);
            
            //если еще не было операций покупки этого вагона
            if (UnitOfWork.Instance.OperationRepository.GetOwner(_wagon) == null) 
            {
                comboBoxTransmitters.DataSource = UnitOfWork.Instance.OperationRepository.GetAllContractors();
                comboBoxReceivers.DataSource = UnitOfWork.Instance.OperationRepository.GetAllContractors();
            }
            else
            {
                Contractor owner = UnitOfWork.Instance.OperationRepository.GetOwner(_wagon);
                comboBoxTransmitters.DataSource = new List<Contractor>() { owner };

                comboBoxReceivers.DataSource = UnitOfWork.Instance.OperationRepository.GetListOfContractorsExceptSpecified(owner);
            }

            dateTimePickerStart.MinDate = UnitOfWork.Instance.OperationRepository.GetPossibleStartNewSale(_wagon);
        }

        private void initFormForRent()
        {
            comboBoxTypes.DataSource = UnitOfWork.Instance.OperationRepository.GetAllRentTypes();
            dateTimePickerEnd.Enabled = true;

            DateTime availableRentStartWithUnlimitedEnd = UnitOfWork.Instance.OperationRepository.GetAvailableStartRentWithUnlimitedEnd(_wagon);
            baseOperationForNewRent = UnitOfWork.Instance.OperationRepository.GetActiveOperationByDate(_wagon, availableRentStartWithUnlimitedEnd);
            Contractor owner = UnitOfWork.Instance.OperationRepository.GetContractorById(baseOperationForNewRent.ReceiverContractorID);
            comboBoxTransmitters.DataSource = new List<Contractor>() { owner };
            comboBoxReceivers.DataSource = UnitOfWork.Instance.OperationRepository.GetListOfContractorsExceptSpecified(owner);
            _rentLevel = 1;


            //арендовать вагон можно датой не раньше даты с которой у этого вагона есть владелец 
            DateTime? firstSaleDate = UnitOfWork.Instance.OperationRepository.GetFirstSaleOperation(_wagon)?.StartDate;
            dateTimePickerStart.MinDate = firstSaleDate <= DateTime.Today ? DateTime.Today : firstSaleDate.Value;
            dateTimePickerEnd.MinDate = dateTimePickerStart.MinDate;

            dateTimePickerStart.Value = availableRentStartWithUnlimitedEnd;

            //период аренды по умолчанию можно установить любой 
            dateTimePickerEnd.Value = dateTimePickerStart.Value.AddYears(1);

            dateTimePickerStart.CloseUp += new EventHandler(updateFormForSelectedStart);
            dateTimePickerEnd.CloseUp += new EventHandler(updateFormForSelectedEnd);
        }
                
        private void updateFormForSelectedStart(object sender, EventArgs e)
        {
            Operation activeBaseOperation = UnitOfWork.Instance.OperationRepository.GetActiveOperationByDate(_wagon, dateTimePickerStart.Value);

            if(baseOperationForNewRent.OperationID != activeBaseOperation.OperationID)
            {
                baseOperationForNewRent = activeBaseOperation;
                Contractor holder = UnitOfWork.Instance.OperationRepository.GetContractorById(baseOperationForNewRent.ReceiverContractorID);
                comboBoxTransmitters.DataSource = new List<Contractor> { holder };

                Contractor selectedReceiver = comboBoxReceivers.SelectedItem as Contractor;
                List<Contractor> possibleReceivers = UnitOfWork.Instance.OperationRepository.GetListOfContractorsExceptSpecified(holder);
                comboBoxReceivers.DataSource = possibleReceivers;
                int index = possibleReceivers.FindIndex(x => x.ContractorID == selectedReceiver.ContractorID);
                if (index != -1)
                    comboBoxReceivers.SelectedIndex = index;

                _rentLevel = baseOperationForNewRent.RentLevel + 1;

                //если базовая операция - это операция продажи,
                //то проверить, если позже еще была операция, тогда ограничить конечную дату базовой операции началом действия следующей операции
                if(!baseOperationForNewRent.EndDate.HasValue)
                {
                    Operation nextOperation = UnitOfWork.Instance.OperationRepository.GetNextDayOperationAfterSpecified(baseOperationForNewRent);
                    baseOperationForNewRent.EndDate = nextOperation?.StartDate.AddDays(-1);
                }
            }

            if (dateTimePickerEnd.Value < dateTimePickerStart.Value || (baseOperationForNewRent.EndDate.HasValue && dateTimePickerEnd.Value > baseOperationForNewRent.EndDate))
            {
                dateTimePickerEnd.Value = baseOperationForNewRent.EndDate ?? dateTimePickerStart.Value;
            }
        }

        private void updateFormForSelectedEnd(object sender, EventArgs e)
        {
            Operation activeBaseOperation = UnitOfWork.Instance.OperationRepository.GetActiveOperationByDate(_wagon, dateTimePickerEnd.Value);

            if (baseOperationForNewRent.OperationID != activeBaseOperation.OperationID)
            {
                baseOperationForNewRent = activeBaseOperation;
                Contractor holder = UnitOfWork.Instance.OperationRepository.GetContractorById(baseOperationForNewRent.ReceiverContractorID);
                comboBoxTransmitters.DataSource = new List<Contractor> { holder };

                Contractor selectedReceiver = comboBoxReceivers.SelectedItem as Contractor;
                List<Contractor> possibleReceivers = UnitOfWork.Instance.OperationRepository.GetListOfContractorsExceptSpecified(holder);
                comboBoxReceivers.DataSource = possibleReceivers;
                int index = possibleReceivers.FindIndex(x => x.ContractorID == selectedReceiver.ContractorID);
                if (index != -1)
                    comboBoxReceivers.SelectedIndex = index;

                _rentLevel = baseOperationForNewRent.RentLevel + 1;

                //если базовая операция - это операция продажи,
                //то проверить, если позже еще была операция, тогда ограничить конечную дату базовой операции началом действия следующей операции
                if (!baseOperationForNewRent.EndDate.HasValue)
                {
                    Operation nextOperation = UnitOfWork.Instance.OperationRepository.GetNextDayOperationAfterSpecified(baseOperationForNewRent);
                    baseOperationForNewRent.EndDate = nextOperation?.StartDate.AddDays(-1);
                }
            }

            if (dateTimePickerStart.Value > dateTimePickerEnd.Value || dateTimePickerStart.Value < baseOperationForNewRent.StartDate)
            {
                dateTimePickerStart.Value = baseOperationForNewRent.StartDate;
            }
        }
        private void radioButtonRent_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonRent.Checked)
            {
                initFormForRent();
            }
            else
            {
                initFormForSale();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxContractNumber.Text))
                {
                    throw new Exception("Contract must have a number!");
                }
                Operation operation = new Operation();
                operation.WagonID = _wagon.WagonID;

                int transmitterID = (comboBoxTransmitters.SelectedItem as Contractor).ContractorID;
                operation.TransmitterContractorID = transmitterID;
                operation.TransmitterDepartmentID = UnitOfWork.Instance.OperationRepository.GetDepartmentByContractorID(transmitterID)?.DepartmentID;

                int receiverID = (comboBoxReceivers.SelectedItem as Contractor).ContractorID;
                operation.ReceiverContractorID = receiverID;
                operation.ReceiverDepartmentID = UnitOfWork.Instance.OperationRepository.GetDepartmentByContractorID(receiverID)?.DepartmentID;

                operation.StartDate = dateTimePickerStart.Value.Date;
                operation.TypeID = (comboBoxTypes.SelectedItem as OperationType).TypeID;
                operation.ContractDate = DateTime.Today;
                operation.ContractNumber = textBoxContractNumber.Text;

                if(radioButtonSale.Checked)
                {
                    operation.RentLevel = 0;
                }
                else
                {
                    operation.RentLevel = _rentLevel;
                    operation.EndDate = dateTimePickerEnd.Value;
                }

                UnitOfWork.Instance.OperationRepository.Create(operation);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
