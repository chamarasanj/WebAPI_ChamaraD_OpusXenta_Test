namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        LoginEmail = c.String(maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SecurityProfileID = c.Int(nullable: false),
                        SecurityProfile = c.String(),
                        UserTypeID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
        }
    }
}
