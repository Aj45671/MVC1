using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class Roles
    {
        [Key]
        public int UserId {  get; set; }
        [Required]
        public string Role {  get; set; }
    }
}