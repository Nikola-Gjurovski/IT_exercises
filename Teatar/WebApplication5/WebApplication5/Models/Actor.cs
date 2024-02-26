using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Pol Pol { get; set; }
        public List< Pretstava> Pretstava { get; set; }
        public Actor()
        {
            Pretstava = new List< Pretstava>();
        }
    }
}