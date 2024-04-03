namespace MyClinic_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appoint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            AddColumn("dbo.Appointments", "PatientName", c => c.String(nullable: false));
            DropColumn("dbo.Appointments", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "PatientName");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
        }
    }
}
