using OnlineCinema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.Models
{
    public class Session
    {
        public DateTime Data { get; set; }
        public TimeSpan Time { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
    }
}