namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSecProfUserNameString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecurityProfile_User", "SecurityProfileName", c => c.String());
            AddColumn("dbo.SecurityProfile_User", "UserName", c => c.String());

           
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.SecurityProfile_User", "UserName", c => c.Int(nullable: false));
            //AlterColumn("dbo.SecurityProfile_User", "SecurityProfileName", c => c.Int(nullable: false));
        }
    }
}
