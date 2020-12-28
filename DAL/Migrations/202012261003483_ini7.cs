namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecurityProfiles",
                c => new
                    {
                        SecurityProfileID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsCreate = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SecurityProfileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecurityProfiles");
        }
    }
}
