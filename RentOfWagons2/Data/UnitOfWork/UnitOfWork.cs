using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork
    {
        private readonly RentOfWagonsEntities _context;

        private static UnitOfWork _instance;
        public static UnitOfWork Instance => _instance ?? (_instance = new UnitOfWork());

        private UnitOfWork()
        {
            _context = new RentOfWagonsEntities();
        }

        private OperationRepository _operationRepository;
        public OperationRepository OperationRepository => _operationRepository ?? (_operationRepository = new OperationRepository(_context));
    }
}
