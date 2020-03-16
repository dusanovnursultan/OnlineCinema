using OnlineCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCinema.DataManager;
using OnlineCinema.EntityModel;
using SeatsModels = OnlineCinema.Models.SeatsModels;
using Newtonsoft.Json;
using System.Data.Entity;

namespace OnlineCinema.Controllers
{
    public class HomeController : Controller
    {
        public static OnlineCinemaContextContainer _db;

        public ActionResult Index()
        {
            _db = new OnlineCinemaContextContainer();
            var movies = _db.MovieSet;
            var hall = _db.HallSet.ToList();
            var listMovies = new PageMovieInfo()
            {
                Movie = movies,
                Hall = hall
            };   
            return View(listMovies);
        }
        public ActionResult DetailsMovie(int id)
        {
            var movie = DataManager.DataManager.FindMovie(id);
            return View(movie);
        }
        public ActionResult Session(int id)
        {
            ViewBag.IdSession = id;
            return View();
        }
        [HttpGet]
        public JsonResult GetTicketOnSession(int id)
        {
            var session = DataManager.DataManager.FindSession(id);
            TicketModels[][] mas = new TicketModels[4][];
            var list =  DataManager.DataManager.GetTickets(id);

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new TicketModels[4];
                var listRow = list.Where(x => x.Row == i.ToString()).Take(4).ToList();
                for (int j = 0; j < listRow.Count; j++)
                {
                    mas[i][j] = listRow[j];
                }
            }
            return Json(new { listTickets = mas }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetParametrHall(int id)
        {
            var session = DataManager.DataManager.FindSession(id);
            var hall = session.Hall.NameHall;
            var movie = session.Movie.Name;
            var price = session.Price;
            
            return Json(new { Movie = movie,Hall = hall,Price = price }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddMovie()
        {
            var model = new Movie();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(HttpPostedFileBase smallImage, Movie model, HttpPostedFileBase bigImage)
        {
            if (!ModelState.IsValid || smallImage == null && smallImage.ContentLength == 0) return RedirectToAction("Index");
            string pathToSave = Server.MapPath(@"~/Content/Images");
            string ext = System.IO.Path.GetExtension(smallImage.FileName);
            string uniqueName = $"{"smallImage"}{smallImage.FileName}{200}x{170}{ext}";
            string fileName = System
                .IO
                .Path
                .Combine(pathToSave, uniqueName);
            smallImage.SaveAs(fileName);
            model.SmallImg = uniqueName;
            ext = System.IO.Path.GetExtension(bigImage.FileName);
            uniqueName = $"{"bigImage"}{smallImage.FileName}{400}x{500}{ext}";
            fileName = System
                .IO
                .Path
                .Combine(pathToSave, uniqueName);
            bigImage.SaveAs(fileName);
            model.BigImg = uniqueName;
            _db = new OnlineCinemaContextContainer();
            _db.MovieSet.Add(model);
            _db.SaveChanges();
            return View("DetailsMovie",model);
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