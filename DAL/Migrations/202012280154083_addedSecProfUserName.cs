namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSecProfUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecurityProfile_User", "SecurityProfileName", c => c.Int(nullable: false));
            AddColumn("dbo.SecurityProfile_User", "UserName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SecurityProfile_User", "UserName");
            DropColumn("dbo.SecurityProfile_User", "SecurityProfileName");
        }
    }
}
