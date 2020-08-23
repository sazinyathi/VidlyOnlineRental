namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfBirthCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDayDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDayDate");
        }
    }
}
