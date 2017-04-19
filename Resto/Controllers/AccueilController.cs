using Resto.Models;
using Resto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resto.Controllers
{
    public class AccueilController : Controller
    {
        private IDal dal;

        public AccueilController() : this(new Dal())
        {
            
        }

        public AccueilController(IDal dalA)
        {
            dal = dalA;
        }


        // GET: Accueil
        public ActionResult Index()
        {
         
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            int idSondage = dal.CreerUnSondage();
            return RedirectToAction("Index", "Vote", new { id = idSondage });
        }
        //public ActionResult AfficheDate(string id)
        //{
        //    ViewBag.Message = "Bonjour " + id + " !";
        //    ViewData["Date"] = new DateTime(2012, 4, 28);
        //    return View("Index");
        //}


    }
}