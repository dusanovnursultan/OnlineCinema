
using OnlineCinema.Data;
using OnlineCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.DataManager
{
    public class Manager
    {
        private static OnlineCinemaContextContainer _db;
        public static List<Movie> FindListFilmInHole( int idHall)
        {
            _db = new OnlineCinemaContextContainer();
            List<Movie> movies = new List<Movie>();
            var hole = _db.HallSet.Find(idHall);
            foreach (var item in hole.Sessions)
            {
                movies.Add(item.Movie);
            }
            return movies;
        }
    }
}
