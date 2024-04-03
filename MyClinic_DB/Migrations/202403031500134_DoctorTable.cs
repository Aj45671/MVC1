namespace MyClinic_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false),
                        Phone = c.Long(nullable: false),
                        Birth_Date = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Charge = c.Int(nullable: false),
                        MonthlySalary = c.Int(nullable: false),
                        Qualification = c.String(),
                        Experience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
