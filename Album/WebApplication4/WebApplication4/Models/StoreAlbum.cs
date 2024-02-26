using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class StoreAlbum
    {
        public List<Album> albums { get; set; }
        public Store Store { get; set; }
        public int selectedAlbum { get; set; }
        public int selectedStore { get; set; }
        public StoreAlbum()

        {
            albums = new List<Album>();
        }
    }
}