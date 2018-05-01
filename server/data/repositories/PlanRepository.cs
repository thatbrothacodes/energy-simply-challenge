using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data.models;

namespace server.data.repositories {
    public class PlanRepository : GenericRepository<Plan>, IPlanRepository 
    {
        private int newId = 1000;
        public override Plan Add(Plan t) {
            using (var transaction = _context.Database.BeginTransaction()) {
                try {
                    t.PlanID = newId;
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Plans] ON");
                    _context.Set<Plan>().Add(t);  
                    _context.SaveChanges(); 
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Plans] OFF"); 
                    transaction.Commit();
                    newId++;
                    return t;
                } catch {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public override async Task<Plan> AddAsyn(Plan t) {
            using (var transaction = _context.Database.BeginTransaction()) {
                try {
                    t.PlanID = newId;
                    await _context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Plans] ON");
                    _context.Set<Plan>().Add(t);  
                    await _context.SaveChangesAsync(); 
                    await _context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Plans] OFF"); 
                    transaction.Commit();
                    newId++;
                    return t;
                } catch {
                    transaction.Rollback();
                    return null;
                }
            }
        }
        public PlanRepository(CRMContext context) : base(context)
        {
        }
    }

    public interface IPlanRepository : IGenericRepository<Plan> {

    }
}