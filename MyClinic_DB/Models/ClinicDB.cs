using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class ClinicDB:DbContext
    {
         
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
       

    
}
}