using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class TeatarPretstava
    {
        public List<Pretstava> Pretstava { get; set; }
        public Teatar teatar { get; set; }
        public int TeatarId { get; set; }
        public int PretstavaId { get; set; }
        public TeatarPretstava()
        {
            Pretstava = new List<Pretstava>();
        }

    }
}