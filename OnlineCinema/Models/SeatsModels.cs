using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCinema.EntityModel;

namespace OnlineCinema.Models
{
    [Serializable]
    public class SeatsModels
    {
        public List<Tickets> Tickets { get; set; }
        public Hall Hall { get; set; }
        public string NameMovie { get; set; }
        public int Price { get; set; }
    }
}