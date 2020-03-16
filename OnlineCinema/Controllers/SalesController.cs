using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using OnlineCinema.EntityModel;
using OnlineCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinema.Controllers
{
    public class SalesController : Controller
    {
        public static OnlineCinemaContextContainer _db;
        [HttpPost]
        [Authorize]
        public ActionResult JsonOrder(TicketModels[] model)
        {
            if (ModelState.IsValid)
            {
                var iduser = User.Identity.GetUserId();
                var listModel = model.ToList();
                foreach (var item in listModel)
                {
                    var order = new Order();
                    order.Tickets.Order = order;
                    order.GuId = iduser,
                }
            }
            return Json(new {success = true });
        }
    }
}