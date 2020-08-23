namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name ='Pay as You Go' where id = 1");
            Sql("UPDATE MembershipTypes SET Name ='Monthly ' where id = 2");
            Sql("UPDATE MembershipTypes SET Name ='3 Months' where id = 3");
            Sql("UPDATE MembershipTypes SET Name ='Yearly' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
