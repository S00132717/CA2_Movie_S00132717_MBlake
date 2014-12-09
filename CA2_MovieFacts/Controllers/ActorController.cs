
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2_MovieFacts.Models;//
using System.Data.Entity;//
using System.Data;//

namespace CA2_MovieFacts.Views.Home
{
    public class ActorController : Controller
    {
        MoviesDbContext _db = new MoviesDbContext();//Connection to the Database

        //sorting       //toast pop-up      //Search Actor
        public ActionResult Index(string alphaOrder, string toast, string searchTerm = null)
        {
            if (!string.IsNullOrEmpty(toast))//If this string is not empty
            {
                ViewBag.toast = toast;//pass the string into the ViewBag
            }

            if (!string.IsNullOrEmpty(searchTerm))//If searchTerm is not empty
            {
                //Look in DB to find ActorName that contains the searchTerm
                ActorViewModel getActor = (from d in _db.Actors
                                           where d.ActorName.Contains(searchTerm)
                                           select new ActorViewModel
                                           {
                                               ActorId = d.ActorId
                                           }).FirstOrDefault();//Get the first item in the query and make an ActorViewModel class out of this
                //Find Actor in DB that has the same ID as the ActorViewModel and return the View
                var actor = _db.Actors.Find(getActor.ActorId);
                return View("Details", actor);
            }


            ViewBag.PageTitle = "List of Actors (Total " + _db.Actors.Count() + ")";//Show number of Actors

            IQueryable<Actor> actors = _db.Actors;

            //Actors alphabetically ordered asc/desc
            if (alphaOrder == null) alphaOrder = "asc";
            ViewBag.alphabetic = (alphaOrder == "asc") ? "desc" : "asc";

            switch (alphaOrder)
            {
                case "desc":
                    ViewBag.alphabetic = "asc";
                    actors = actors.OrderByDescending(a => a.ActorName);
                    break;
                case "asc":
                    ViewBag.alphabetic = "desc";
                    actors = actors.OrderBy(a => a.ActorName);
                    break;
            }
            return View (actors.ToList());
        }


        //
        // GET: /Actor/Details/5
        public ActionResult Details(int id)
        {
            var actors = _db.Actors.Find(id);
            return View(actors);
        }


        public PartialViewResult MovieDetails(int id)
        {
            var movies = _db.Movies.Find(id);
            return PartialView("_MovieDetails", movies);//return partial view of Movie details, to appear with Actor details
        }


        //
        // GET: /Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actor/Create
        [HttpPost]
        public ActionResult Create(Actor newActor)
        {
            try
            {   //Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var _db2 = new MoviesDbContext())
                    {
                        _db2.Actors.Add(newActor);
                        _db2.SaveChanges();
                    }                               //sending string 'create' back to Index on creation of new Actor
                    return RedirectToAction("Index", new { toast = "Create" });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Actor/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActorList = _db.Actors.ToList();
            return View(_db.Actors.Find(id));
        }

        //
        // POST: /Actor/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Actor editActor)
        {
            try
            {
                // Find the record in the db using the Actor ID
                // Copy the edited one across to the retrieved one
                // Save back to database
                _db.Entry(editActor).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Actor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Actors.Find(id));
        }

        //
        // POST: /Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Actors.Remove(_db.Actors.Find(id));
            //_db.SaveChanges();//
            //_db.Movies.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}