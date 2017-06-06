using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace RentOfWagons
{
    class viewOperationModel
    {
        public int OperationID { get; set; }
        public string ContractNumber { get; set; }
        public string Attribute { get; set; }
        public int RentLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TransmitterContractor { get; set; }
        public string TransmitterDepartment { get; set; }
        public string ReceiverContractor { get; set; }
        public string ReceiverDepartment { get; set; }
        public DateTime ContractDate { get; set; }
        
        public viewOperationModel(Operation op)
        {
            OperationID = op.OperationID;
            ContractNumber = op.ContractNumber;
            Attribute = op.OperationType.Attribute == (int)OperationTypesAttributes.Rent ? "Аренда" : "Купля";
            RentLevel = op.RentLevel;
            StartDate = op.StartDate;
            EndDate = op.EndDate;
            TransmitterContractor = op.Contractor1.Name;
            TransmitterDepartment = op.Department1?.Name;
            ReceiverContractor = op.Contractor.Name;
            ReceiverDepartment = op.Department?.Name;
            ContractDate = op.ContractDate;
        }
    }
}
