namespace MyClinic_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
