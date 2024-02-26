using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public Store()
        {
            Albums = new List<Album>();
        }
    }
}