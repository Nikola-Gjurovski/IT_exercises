using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [StringLength(6,MinimumLength =6)]
        public string Name { get; set; }
        public string AlbumUrl { get; set; }
        public int ArtisId { get; set; }
        [Display(Name="Genre")]
        public int GenreId { get; set; }
        public Genre genre { get; set; }
        [Display(Name="Artist")]
        public Artist artist { get; set; }
        [Range(100,300)]
        public decimal price { get; set; }
        public virtual ICollection<Store> Stors { get; set; }
        public Album()
        {
            Stors = new List<Store>();
        }
    }
}