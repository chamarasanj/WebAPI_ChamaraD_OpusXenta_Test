namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSecProfUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecurityProfile_User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SecurityProfileID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecurityProfile_User");
        }
    }
}
