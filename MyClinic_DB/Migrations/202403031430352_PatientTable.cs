namespace MyClinic_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false),
                        Phone_NO = c.Long(nullable: false),
                        Birth_Date = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
