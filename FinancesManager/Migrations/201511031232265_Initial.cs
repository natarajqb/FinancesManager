namespace FinancesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Expenses",
            //    c => new
            //        {
            //            ExpenseId = c.Int(nullable: false, identity: true),
            //            Title = c.String(),
            //            Amount = c.Double(nullable: false),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ExpenseId);

            AddColumn("dbo.People", "LocationTmp", c => c.Int(nullable: false));
            Sql(@"
    UPDATE dbp.People
    SET LocationTmp =
        CASE Location
            WHEN 'London' THEN 1
            WHEN 'Edinburgh' THEN 2
            WHEN 'Cardiff' THEN 3
            ELSE 0
        END
    ");
            DropColumn("dbo.People", "Location");
            RenameColumn("dbo.People", "LocationTmp", "Location");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenses");
        }
    }
}
