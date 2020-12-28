namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSecProf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "SecurityProfileID");
            DropColumn("dbo.Users", "SecurityProfile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SecurityProfile", c => c.String());
            AddColumn("dbo.Users", "SecurityProfileID", c => c.Int(nullable: false));
        }
    }
}
