using OnlineCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCinema.DataManager;
using OnlineCinema.Data;

namespace OnlineCinema.Controllers
{
    public class HomeController : Controller
    {
        public static OnlineCinemaContextContainer _db;

        public ActionResult Index()
        {
            _db = new OnlineCinemaContextContainer();
            var gg = Manager.FindListFilmInHole(2);
            var movie = _db.MovieSet;
            var model = new MovieModel();
            foreach (var item in movie)
            {  
                model.Name = item.Name;
                model.Description = item.Description;
                model.SmallImg = item.SmallImg;
                model.Assessment = item.Assessment;
                model.Duration = item.Duration;
            }
            model.Tickets = new List<Tickets>();
            var session = _db.SessionsSet;
            var t = new Ticket();
            var fgh = session.Take(6).ToList();
            fgh.Take(6).Where(item => item.Tickets);
            foreach (var s in session)
            {
                foreach (var ticket in s.Tickets)
                {
                    model.Tickets.Add(ticket);
                }
            }
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}