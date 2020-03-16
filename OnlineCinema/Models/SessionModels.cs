using OnlineCinema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.Models
{
    public class SessionModels
    {
        public TimeSpan Time { get; set; }
        public Movie Movie { get; set; }
    }
}