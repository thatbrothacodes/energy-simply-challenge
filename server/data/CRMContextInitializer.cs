using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.data.models;

public static class CRMContextInitializer
{
    public static async Task Initialize(CRMContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        if(!context.Plans.Any()) {
            using (var transaction = context.Database.BeginTransaction()) {
                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Plans] ON");

                context.Plans.Add(new Plan {
                    PlanID = 123,
                    PlanName = "ComEd 6",
                    PlanFixedCost = 7.99M,
                    PlanVarCost = 0.10M
                });

                context.Plans.Add(new Plan {
                    PlanID = 456,
                    PlanName = "Amigo 3",
                    PlanFixedCost = 0M,
                    PlanVarCost = 0.12M
                });

                context.Plans.Add(new Plan {
                    PlanID = 789,
                    PlanName = "Amigo 12",
                    PlanFixedCost = 4.99M,
                    PlanVarCost = 0.11M
                });

                await context.SaveChangesAsync();

                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Plans] OFF");
                transaction.Commit();
            }
        }

        if (!context.Customers.Any())
        {
            using (var transaction = context.Database.BeginTransaction()) {

                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Customers] ON");

                context.Customers.Add(new Customer { 
                    CustID = 12, 
                    CustEmail = "anne@gmail.com", 
                    CustName = "Anne", 
                    CustPlanID = 123 
                });

                context.Customers.Add(new Customer { 
                    CustID = 34, 
                    CustEmail = "bob@hotmail.com", 
                    CustName = "Bob", 
                    CustPlanID = 456 
                });

                context.Customers.Add(new Customer { 
                    CustID = 56, 
                    CustEmail = "chris@yahoo.com", 
                    CustName = "Chris", 
                    CustPlanID = 789 
                });

                context.Customers.Add(new Customer { 
                    CustID = 78, 
                    CustEmail = "david@aol.com", 
                    CustName = "David", 
                    CustPlanID = 123 
                });

                context.Customers.Add(new Customer { 
                    CustID = 90, 
                    CustEmail = "eric@energysimp.ly ", 
                    CustName = "Eric", 
                    CustPlanID = 123 
                });
                
                await context.SaveChangesAsync();

                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Customers] OFF");
                transaction.Commit();
            }
            
        }
    }
}