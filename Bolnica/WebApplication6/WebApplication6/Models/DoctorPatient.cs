using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class DoctorPatient
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
        public DoctorPatient() { 
        Patients = new List<Patient>();
        }
    }
}