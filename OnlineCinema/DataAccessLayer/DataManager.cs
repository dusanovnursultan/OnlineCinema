
using OnlineCinema.EntityModel;
using OnlineCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace OnlineCinema.DataManager
{
    public class DataManager : Controller
    {
        private static OnlineCinemaContextContainer _db;
        public DataManager()
        {
            
        } 

        public static List<TicketModels> GetTickets(int idSession)
        {
            var session = FindSession(idSession);

            var ticketModels = session
                .Tickets
                .Select(x => new TicketModels(x))
                .ToList();
            return ticketModels;
            /*
            foreach (var item in session.Tickets)
            {
                var model = new TicketModels();
               
                ticketModels.Add(model);
            }
            */
        }
        public static Movie FindMovie(int id)
        {
            _db = new OnlineCinemaContextContainer();
            return _db.MovieSet.Find(id);
        }
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

        public static Sessions FindSession(int id)
        {
            _db = new OnlineCinemaContextContainer();
            return _db.SessionsSet.Find(id);
        }
    }
}
