namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSecProfUserNameString22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecurityProfile_User", "SecurityProfileName", c => c.String());
            AddColumn("dbo.SecurityProfile_User", "UserName", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
