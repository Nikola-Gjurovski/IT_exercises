using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    public class Artist
    {
        [Display(Name = "Id")]
        [Key]
        public int ArtisId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}