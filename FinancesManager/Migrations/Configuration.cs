using FinancesManager.Models;

namespace FinancesManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinancesManager.Models.FinancesManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinancesManager.Models.FinancesManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Expenses.AddOrUpdate(p => p.Title,
                                         new Expense
                                             {
                                                 Amount = 10000.00,
                                                 Date = DateTime.Now,
                                                 Title = "Rent"
                                             },
                                              new Expense
                                              {
                                                  Amount = 1500.00,
                                                  Date = DateTime.Now,
                                                  Title = "Groceries"
                                              }
                );
        }
    }
}
