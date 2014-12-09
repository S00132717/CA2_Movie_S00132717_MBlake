using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2_MovieFacts.Models;

namespace CA2_MovieFacts.Controllers
{
    public class ScreenNameController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        //
        // GET: /ScreenName/Create
        public PartialViewResult Create()
        {
            ///Put a list of Actors and a list of Movies into the ViewBag
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle");
            return PartialView("_CreateScreenName");
        }

        //
        // POST: /ScreenName/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScreenName screenname)
        {
            if (ModelState.IsValid)
            {
                db.ScreenNames.Add(screenname);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new{id=screenname.MovieId});
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", screenname.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle", screenname.MovieId);
            return View(screenname);
        }
    }
}