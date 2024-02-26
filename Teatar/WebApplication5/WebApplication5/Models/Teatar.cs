using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Teatar
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        public virtual ICollection<Pretstava> Pretstava { get; set;}
        public Teatar() { 
        Pretstava = new List<Pretstava>();
        }
    }
}