Challenge A: Build a simple SQL database and three ASP.net web pages:

* AddCustomer.aspx – Adds a customer (including the current plan they are in)

* AddPlan.aspx – Adds a new plan

* ListCustomersAndPlans.aspx – Displays a list of customers and plans

Here is sample data that should be pre-populated in the Customers and Plans tables:

| CustID (int) | CustName (string) | CustEmail (string) | CustPlanID (int)
| --- | --- | --- | --- |
| 12 | Anne | anne@gmail.com | 123 |
| 34 | Bob | bob@hotmail.com | 456 |
| 56 | Chris | chris@yahoo.com | 789 |
| 78 | David | david@aol.com | 123 |
| 90 | Eric | eric@energysimp.ly | 123 |

| PlanID (int) | PlanName (string) | PlanFixedCost (decimal) | PlanVarCost (decimal) |
| --- | --- | --- | --- |
| 123 | ComEd | 6 | 7.99 | 0.10 |
| 456 | Amigo | 3 | 0 | 0.12 |
| 789 | Amigo | 12 | 4.99 | 0.11 |

ListCustomersAndPlans.aspx should display a list of the customers and their plans in a simple table. There should be hyperlinks to your add customer and add plan web pages at the bottom:

| CustID | CustName | CustEmail | PlanName | PlanFixedCost | PlanVarCost |
| --- | --- | --- | --- | --- | --- |
| 12 | Anne | Anne@gmail.com | ComEd | 6 | 7.99 | 0.10 |
| … |

[Add Customer]() | [Add Plan]()

Your submission should be a link to your hosted, running ListCustomersAndPlans.aspx page.