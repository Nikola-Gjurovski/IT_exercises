using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Hospitals")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public Doctor() { 
        Patients = new List<Patient>(); 
        }
    }
}