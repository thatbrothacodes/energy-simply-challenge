using Microsoft.EntityFrameworkCore;
using System.Data;

using server.data.models;

namespace server.data
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options): base(options) { 

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Customer>(b =>
            {
                b.HasKey(u => u.CustID);
                b.HasOne(u => u.Plan)
                    .WithMany()
                    .HasForeignKey(u => u.CustPlanID);
            });
            
            builder.Entity<Plan>(b =>
            {
                b.HasKey(u => u.PlanID);
            });

            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Plan> Plans { get; set; }

    }
}