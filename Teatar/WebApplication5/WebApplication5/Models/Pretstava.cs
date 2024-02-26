using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Pretstava
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Akteri")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [Range(300,500)]
        public decimal Price { get; set; }
        [StringLength(6,MinimumLength =6)]
        public string code { get; set; }
        public virtual ICollection<Teatar> teatar { get; set;}
        public Pretstava()
        {
            teatar=new List<Teatar>();  
        }
    }
}