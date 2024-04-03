using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
       
        public long Phone_NO { get; set; }
        [Required]
        public DateTime Birth_Date { get; set; }
        [Required]
        public string Gender { get; set; }

    }
   
}