namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Gernes", newName: "Genres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Genres", newName: "Gernes");
        }
    }
}
