using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineCinema.EntityModel;
namespace OnlineCinema.Models
{
    public class PageMovieInfo
    {
        public DbSet<Movie> Movie { get; set; }
        public List<Hall> Hall { get; set; }
    }
}