using OnlineCinema.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.Models
{
    public class MovieModel
    {

        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public string SmallImg { get; set; }
        public string BigImg { get; set; }
        public int Assessment { get; set; }
        public DateTime StartOfRental { get; set; }
        public int AgeRestriction { get; set; }
    }
}