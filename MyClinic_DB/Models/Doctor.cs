using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [Display(Name ="Doctor Name")]
        public string DoctorName { get; set; }
        [Required]
       
        public long Phone { get; set; }
        [Required]
        public DateTime Birth_Date { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        public int Charge {  get; set; }
        public int MonthlySalary {  get; set; }
        public string Qualification {  get; set; }
        public int Experience { get; set;}
    }
   
}