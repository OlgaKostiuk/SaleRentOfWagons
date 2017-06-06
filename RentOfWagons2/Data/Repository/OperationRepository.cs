using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Data
{
    public enum OperationTypesAttributes { Sale = 0, Rent = 1 }
    public class OperationRepository : ICrud<Operation>
    {
        private readonly RentOfWagonsEntities _dbContext;
        public OperationRepository(RentOfWagonsEntities context)
        {
            _dbContext = context;
        }


        public Operation Create(Operation model)
        {
            _dbContext.Operations.Add(model);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                _dbContext.Operations.Local.Remove(model);
                throw;
            }
            
            return model;
        }

        public void Delete(int id)
        {
            _dbContext.Operations.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public Operation GetById(int id)
        {
            return _dbContext.Operations.Find(id);
        }

        public Operation Update(Operation model)
        {
            Operation original = _dbContext.Operations.FirstOrDefault(x => x.OperationID == model.OperationID);
            if (original == null)
                return null;
            _dbContext.Entry(original).CurrentValues.SetValues(model);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                _dbContext.Entry(original).CurrentValues.SetValues(original);
                throw;
            }
            return model;
        }





        public List<Wagon> GetAllWagons()
        {
            return _dbContext.Wagons.ToList();
        }
        public List<Contractor> GetAllContractors()
        {
            return _dbContext.Contractors.ToList();
        }

        public List<OperationType> GetAllSaleTypes()
        {
            return _dbContext.OperationTypes.Where(x => x.Attribute == (int)OperationTypesAttributes.Sale).ToList();
        }

        public List<OperationType> GetAllRentTypes()
        {
            return _dbContext.OperationTypes.Where(x => x.Attribute == (int)OperationTypesAttributes.Rent).ToList();
        }

        public List<Operation> GetAllOperationsByWagon(Wagon wagon)
        {
            _dbContext.Operations.Where(x => x.WagonID == wagon.WagonID).Load();
            return _dbContext.Operations.Local.Where(x => x.WagonID == wagon.WagonID).ToList();
        }


        public Wagon GetWagonById(int id)
        {
            return _dbContext.Wagons.Find(id);
        }
        public Contractor GetContractorById(int id)
        {
            return _dbContext.Contractors.Find(id);
        }
        public OperationType GetTypeById(int id)
        {
            return _dbContext.OperationTypes.Find(id);
        }
        public Department GetDepartmentByContractorID(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.ContractorID == id);
        }



        public List<Operation> GetListOfOperations(Wagon wagon)
        {
            return _dbContext.Operations.Where(x => x.WagonID == wagon.WagonID).ToList();
        }

        public Operation GetFirstSaleOperation(Wagon wagon)
        {
            return GetListOfOperations(wagon).Where(x => x.WagonID == wagon.WagonID && x.RentLevel == 0).OrderBy(x => x.StartDate).FirstOrDefault();
        }

        //получение операции, которая определяет последнего владельца
        public Operation GetLastSaleOperation(Wagon wagon)
        {
            return GetListOfOperations(wagon).Where(x => x.WagonID == wagon.WagonID && x.RentLevel == 0).OrderByDescending(x => x.StartDate).FirstOrDefault();
        }
        public Contractor GetOwner(Wagon wagon)
        {
            Operation lastSale = GetLastSaleOperation(wagon);
            if (lastSale == null) return null;
            return GetContractorById(lastSale.ReceiverContractorID);
        }

        public DateTime? GetLatestDateRentExpiresOn(Wagon wagon)
        {
            Operation rentOperation = GetListOfOperations(wagon).Where(x => GetTypeById(x.TypeID).Attribute == (int)OperationTypesAttributes.Rent).OrderByDescending(x => x.EndDate).FirstOrDefault();
            return rentOperation?.EndDate;
        }

        public DateTime GetPossibleStartNewSale(Wagon wagon)
        {
            DateTime today = DateTime.Today;

            //дата вступления во владение
            DateTime? takePossessionDate = GetLastSaleOperation(wagon)?.StartDate;

            //дата когда истекает срок аренды
            DateTime? latestRentDate = GetLatestDateRentExpiresOn(wagon);

            //если не было операций покупки этого вагона
            if (!takePossessionDate.HasValue)
                return today;

            //если срок аренды вагона уже истек или по вагону не было операций аренды, то продать можно на следующий день после вступление во владение
            if (latestRentDate < today || !latestRentDate.HasValue)
            {
                return (takePossessionDate < today ? today : takePossessionDate?.AddDays(1)) ?? today;
            }

            //если срок аренды еще не истек - продать можно только начиная с даты когда вагон возвращается в управление владельца
            return latestRentDate > takePossessionDate ? latestRentDate.Value.AddDays(1) : takePossessionDate.Value.AddDays(1);
        }

        public DateTime GetAvailableStartRentWithUnlimitedEnd(Wagon wagon)
        {
            DateTime today = DateTime.Today;

            //дата вступления во владение
            DateTime takePossessionDate = GetLastSaleOperation(wagon).StartDate;

            //дата когда истекает срок аренды
            DateTime? latestRentDate = GetLatestDateRentExpiresOn(wagon);

            //если срок аренды вагона уже истек или по вагону не было операций аренды, то сдать в аренду можно в день втупления во владение
            if (latestRentDate < today || !latestRentDate.HasValue)
            {
                return takePossessionDate < today ? today : takePossessionDate;
            }

            //если срок аренды еще не истек - сдать в аренду без ограничения конечной даты можно только начиная с даты когда вагон возвращается в управление владельца
            return latestRentDate > takePossessionDate ? latestRentDate.Value.AddDays(1) : takePossessionDate;
        }

        public List<Operation> GetNotExpiredRents(Wagon wagon)
        {
            return _dbContext.Operations.Where(x => x.WagonID == wagon.WagonID && x.EndDate >= DateTime.Today).ToList();
        }

        public List<Operation> GetNotExpiredOwnerRentsOut(Wagon wagon)
        {
            Contractor owner = GetOwner(wagon);
            return _dbContext.Operations.Where(x => x.WagonID == wagon.WagonID && x.TransmitterContractorID == owner.ContractorID && x.EndDate >= DateTime.Today).ToList();
        }

        public List<Contractor> GetListOfContractorsExceptSpecified(Contractor contractor)
        {
            List<Contractor> list = GetAllContractors();
            list.Remove(list.First(x => x.ContractorID == contractor.ContractorID));
            return list;
        }
        
        //получение операции, которая определяет управляющего вагоном в указанную дату
        public Operation GetActiveOperationByDate(Wagon wagon, DateTime date)
        {
            //все операции по вагону срок действия которых включает указанную дату
            List<Operation> list = _dbContext.Operations.Where(x => x.WagonID == wagon.WagonID 
                                                                && x.StartDate <= date
                                                                && (x.EndDate == null || x.EndDate >= date))
                                                                .ToList();
                                                                //.Where(x => x.EndDate == null || x.EndDate >= date)
                                                                //.ToList();
            //оставляем только последнюю операцию продажи 
            DateTime latestSaleDate = list.Where(x => x.RentLevel == 0).Max(x => x.StartDate);
            list.RemoveAll(x => x.RentLevel == 0 && x.StartDate != latestSaleDate);

            if (list.Count == 0)
                return null;
            //выбираем операцию с максимальным уровнем
            int maxLevel = list.Max(x => x.RentLevel);
            Operation activeOperation = list.First(x => x.RentLevel == maxLevel);
            return activeOperation;
        }
        public Operation GetNextDayOperationAfterSpecified(Operation operation)
        {
            return _dbContext.Operations.Where(x => x.WagonID == operation.WagonID && x.StartDate > operation.StartDate)
                .OrderBy(x => x.StartDate).FirstOrDefault();
        }

        public List<Operation> GetChildOperations(Operation operation)
        {
            //если аргумент - операция аренды, то выбираем все аренды с вложенным сроком действия
            if (operation.RentLevel > 0)
            {
                return _dbContext.Operations.Where(x => x.WagonID == operation.WagonID
                && x.StartDate >= operation.StartDate
                && x.EndDate <= operation.EndDate
                && x.OperationID != operation.OperationID)
                .ToList();
            }
            else //аргумент - операция продажи, то выбираем все продажи и аренды срок действия которых начнется позже чем срок действия продажи-аргумента
            {
                return _dbContext.Operations.Where(x => x.WagonID == operation.WagonID
                && ((x.RentLevel == 0 && x.StartDate > operation.StartDate) || (x.RentLevel > 0 && x.StartDate >= operation.StartDate))).ToList();
            }
        }

        public Operation GetLastPreviousRentForSpecifiedSale(Operation sale)
        {
            if (sale.RentLevel != 0)
                throw new Exception("The passed operation is not a sale");
            return _dbContext.Operations.Where(x => x.WagonID == sale.WagonID && x.RentLevel == 1 && x.EndDate < sale.StartDate).OrderByDescending(x => x.EndDate).FirstOrDefault();
        }

        public Operation GetLastPreviousSaleForSpecifiedSale(Operation sale)
        {
            if (sale.RentLevel != 0)
                throw new Exception("The passed operation is not a sale");
            return _dbContext.Operations.Where(x => x.WagonID == sale.WagonID && x.RentLevel == 0 && x.StartDate < sale.StartDate).OrderByDescending(x => x.StartDate).FirstOrDefault();
        }

        public Operation GetParentRentForSpecifiedRent(Operation rent)
        {
            if (rent.RentLevel == 0)
                throw new Exception("The passed operation is not a rent");
            if (rent.RentLevel == 1)
                return null;
            return _dbContext.Operations.Where(x => x.WagonID == rent.WagonID
            && x.RentLevel == rent.RentLevel - 1
            && x.StartDate <= rent.StartDate
            && x.EndDate >= rent.EndDate).First();
        }

        public Operation GetParentSaleForSpecifiedRent(Operation rent)
        {
            if (rent.RentLevel == 0)
                throw new Exception("The passed operation is not a rent");
            return _dbContext.Operations.Where(x => x.WagonID == rent.WagonID
            && x.RentLevel == 0
            && x.StartDate <= rent.StartDate)
            .OrderByDescending(x => x.StartDate)
            .First();
        }

        public Operation GetNextSaleForSpecifiedOperation(Operation operation)
        {
            return _dbContext.Operations.Where(x => x.WagonID == operation.WagonID
            && x.RentLevel == 0
            && x.StartDate > operation.StartDate)
            .OrderByDescending(x => x.StartDate)
            .FirstOrDefault();
        }
        public List<Operation> GetSameLevelRentsInCommonParent(Operation rent)
        {
            if (rent.RentLevel == 0)
                throw new Exception("The passed operation is not a rent");
            if(rent.RentLevel > 1)
            {
                Operation parentRent = GetParentRentForSpecifiedRent(rent);
                return _dbContext.Operations.Where(x => x.WagonID == rent.WagonID
                && x.RentLevel == rent.RentLevel
                && x.StartDate >= parentRent.StartDate
                && x.EndDate <= parentRent.EndDate
                && x.OperationID != rent.OperationID)
                .ToList();
            }
            else //если аренда первого уровня
            {
                Operation parentSale = GetParentSaleForSpecifiedRent(rent);
                Operation nextSale = GetNextSaleForSpecifiedOperation(rent);

                List<Operation> sameLevelRentsAfterParentSale = _dbContext.Operations.Where(x => x.WagonID == rent.WagonID
                && x.RentLevel == rent.RentLevel
                && x.StartDate >= parentSale.StartDate)
                .ToList();
                if (nextSale == null) //если после родительской операции продажи нет продаж
                {
                    return sameLevelRentsAfterParentSale;
                }
                else
                    return sameLevelRentsAfterParentSale.Where(x => x.EndDate > nextSale.StartDate).ToList();
            }
        }
    }
}
