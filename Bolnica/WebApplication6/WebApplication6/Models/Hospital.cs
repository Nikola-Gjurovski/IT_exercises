using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalDescription { get; set; }
        public string Url { get; set; }
        [Range(1000, 9999)]
        [DisplayFormat(DataFormatString ="{0:0000}", ApplyFormatInEditMode = true)]
        public int code { get; set;}
        public string Location { get; set;}
    }
}