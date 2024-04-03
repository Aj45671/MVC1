using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyClinic_DB.Models
{
    public class Users
    {
        [Key]
        public int LoginId {  get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Type {  get; set; }
    }
}