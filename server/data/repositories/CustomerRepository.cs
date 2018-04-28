using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data.models;

namespace server.data.repositories {
    public class CustomerRepository  : GenericRepository<Customer>, ICustomerRepository
    {
        private int newId = 100;
        public override async Task<ICollection<Customer>> GetAllAsync()  
        {  
            return await _context.Set<Customer>()
                            .Include(p => p.Plan).ToListAsync();  
        } 
        public override Customer Add(Customer t) {
            using (var transaction = _context.Database.BeginTransaction()) {
                try {
                    t.CustID = newId;
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Customers] ON");
                    _context.Set<Customer>().Add(t);  
                    _context.SaveChanges(); 
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Customers] OFF"); 
                    transaction.Commit();
                    newId++;
                    return t;
                } catch {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public override async Task<Customer> AddAsyn(Customer t) {
            using (var transaction = _context.Database.BeginTransaction()) {
                try {
                    t.CustID = newId;
                    await _context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Customers] ON");
                    _context.Set<Customer>().Add(t);  
                    await _context.SaveChangesAsync(); 
                    await _context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Customers] OFF"); 
                    transaction.Commit();
                    newId++;
                    return t;
                } catch {
                    transaction.Rollback();
                    return null;
                }
            }
        }
        public CustomerRepository(CRMContext context) : base(context)
        {
        }
    }

    public interface ICustomerRepository : IGenericRepository<Customer> {

    }
}