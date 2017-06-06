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
    public partial class UpdateSale : Form
    {
        private readonly Operation _originalSale;
        private readonly Wagon _wagon;
        public UpdateSale(Operation original)
        {
            InitializeComponent();
            _originalSale = original;
            _wagon = UnitOfWork.Instance.OperationRepository.GetWagonById(_originalSale.WagonID);
        }

        private void UpdateSale_Load(object sender, EventArgs e)
        {
            initForm();
            initDateTimePickerStart();
            ActiveControl = dateTimePickerStart;
        }

        private void initForm()
        {
            //нельзя редактировать поля: вагон, номер контракта, продавец, покупатель
            labelWagonNumber.Text += _wagon.Number.ToString("D8");
            labelContractNumber.Text += _originalSale.ContractNumber;
            textBoxTransmitter.ReadOnly = true;
            textBoxReceiver.ReadOnly = true;
            if (_originalSale.TransmitterContractorID.HasValue)
                textBoxTransmitter.Text = UnitOfWork.Instance.OperationRepository.GetContractorById(_originalSale.TransmitterContractorID.Value).Name;
            textBoxReceiver.Text = UnitOfWork.Instance.OperationRepository.GetContractorById(_originalSale.ReceiverContractorID).Name;

            comboBoxOperationType.DisplayMember = "Name";
            comboBoxOperationType.DataSource = UnitOfWork.Instance.OperationRepository.GetAllSaleTypes();
        }

        private void initDateTimePickerStart()
        {
            //Определяем минимально возмождую дату:

            //если выбранная операция продажи - это первая операция для этого вагона, тогда продажа возможна начиная с сегодняшнего дня
            if(UnitOfWork.Instance.OperationRepository.GetFirstSaleOperation(_wagon).OperationID == _originalSale.OperationID)
            {
                dateTimePickerStart.MinDate = DateTime.Today;
            }
            else //перед выбранной операцией продажи уже проводились продажи, тогда продажа возможна
                 //не раньше чем закончится срок действия предшествующей аренды и
                 //не раньше вступления в силу предшествующей продажи (имеет смысл проверять, если предшествующих аренд не было) и
                 //не раньше сегодняшнего дня
            {
                DateTime? lastPrevRentExpire = UnitOfWork.Instance.OperationRepository.GetLastPreviousRentForSpecifiedSale(_originalSale)?.EndDate;
                DateTime lastPrevSale = UnitOfWork.Instance.OperationRepository.GetLastPreviousSaleForSpecifiedSale(_originalSale).StartDate;
                DateTime maxDate = lastPrevRentExpire ?? lastPrevSale;
                dateTimePickerStart.MinDate = DateTime.Today >= maxDate.AddDays(1) ? DateTime.Today : maxDate.AddDays(1);
            }

            //Определяем максимально возможную дату:

            //нужно выбрать самую раннюю дату для дочерних операций выбранной операции продажи,
            //т.к. операция продажи не может вступать в силу позже, чем вступают в силу договора аренды заключенные покупателем
            //и не может вступать в силу позже, чем покупатель перепродаст вагон
            Operation child = UnitOfWork.Instance.OperationRepository.GetChildOperations(_originalSale).OrderBy(x => x.StartDate).FirstOrDefault();
            //если дочерних операций нет, то максимально возможную дату не ограничиваем
            dateTimePickerStart.MaxDate = child != null ? child.StartDate.AddDays(-1) : DateTime.MaxValue;

            dateTimePickerStart.Value = _originalSale.StartDate;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Operation updatedOperation = new Operation();
                updatedOperation.OperationID = _originalSale.OperationID;
                updatedOperation.WagonID = _originalSale.WagonID;
                updatedOperation.TransmitterContractorID = _originalSale.TransmitterContractorID;
                updatedOperation.TransmitterDepartmentID = _originalSale.TransmitterDepartmentID;
                updatedOperation.ReceiverContractorID = _originalSale.ReceiverContractorID;
                updatedOperation.ReceiverDepartmentID = _originalSale.ReceiverDepartmentID;
                updatedOperation.ContractNumber = _originalSale.ContractNumber;
                updatedOperation.RentLevel = _originalSale.RentLevel;

                updatedOperation.ContractDate = DateTime.Today;
                updatedOperation.TypeID = (comboBoxOperationType.SelectedItem as OperationType).TypeID;
                updatedOperation.StartDate = dateTimePickerStart.Value;

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
