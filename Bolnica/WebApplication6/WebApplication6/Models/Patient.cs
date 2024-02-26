using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0,99)]
        public int age { get; set; }
        public Pol Pol { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public Patient() { 
        Doctors = new List<Doctor>();
        }
    }
}