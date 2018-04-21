using server.data;
using server.data.models;
using server.data.repositories;

namespace server.data {
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMContext _context;
        private ICustomerRepository _customerRepository;
        private IPlanRepository _planRepository;
        public UnitOfWork(CRMContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new CustomerRepository(_context);
            }
        }

        public IPlanRepository PlanRepository
        {
            get
            {
                return _planRepository = _planRepository ?? new PlanRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}