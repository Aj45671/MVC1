namespace MyClinic_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientTableFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointId = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Bill = c.Int(nullable: false),
                        Desease = c.String(nullable: false),
                        Prescription = c.String(nullable: false),
                        Progress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AppointId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.Appointments");
        }
    }
}
