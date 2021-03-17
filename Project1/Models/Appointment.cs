using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int ApptID { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        public DateTime ApptTime { get; set; }
        [Required]
        public string GroupEmail { get; set; }
        public string PhoneNum { get; set; }
        //optional
    }
}
