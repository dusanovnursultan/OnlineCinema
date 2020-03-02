using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCinema.Data;
namespace OnlineCinema.Models
{
    public class PageMovieInfo
    {
        public List<MovieModel> Movies { get; set; }
        public  Session Session{ get; set; }
    }
}