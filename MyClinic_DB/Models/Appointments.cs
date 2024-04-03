using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class Appointments
    {
        [Key]
        public int AppointId { get; set; }
        [Required]
        public int DoctorId {  get; set; }
        [Required]
        [Display(Name="Patient Name")]
        public string PatientName{  get; set; }
        [Required]
       
        public DateTime Date { get; set;}
        [Required]
        public int Bill {  get; set;}
        [Required]
        public string Desease {  get; set;}
        [Required]
        public string Prescriptions { get; set;}
        [Required]
        public string Progress {  get; set;}
        [ForeignKey("DoctorId")]
       
        public virtual Doctor Doctor { get; set;}
     
       

    }
}