using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Net;
using CA2_MovieFacts.Models;//
using System.Data.Entity;//
using System.Data;//

namespace CA2_MovieFacts.Controllers
{
    public class HomeController : Controller
    {
        MoviesDbContext _db = new MoviesDbContext();//Connection to the Database

                                    //sorting       //toast pop-up      //Search Movie
        public ActionResult Index(string sortOrder, string toast, string searchTerm = null)
        {
            if (!string.IsNullOrEmpty(toast))//If this string is not empty
            {
                ViewBag.toast = toast;//pass the string into the ViewBag
            }

            if(!string.IsNullOrEmpty(searchTerm))//If searchTerm is not empty
            {
                //Look in DB to find MovieTitle that contains the searchTerm
                MovieViewModel getMovie = (from d in _db.Movies
                                  where d.MovieTitle.Contains(searchTerm)
                                           select new MovieViewModel
                                  {
                                      MovieId = d.MovieId
                                  }).FirstOrDefault();//Get the first item in the query and make a MovieViewModel class out of this
                //Find Movie in DB that has the same ID as the MovieViewModel and return the View
                var movie = _db.Movies.Find(getMovie.MovieId);
                return View("Details", movie);
            }

            ViewBag.PageTitle = "List of Movies (Total " + _db.Movies.Count() + ")";//Show number of Movies

            //Year of Film numerically ordered asc/desc
            if (sortOrder == null) sortOrder = "ascNumber";
            ViewBag.numberOrder = (sortOrder == "ascNumber") ? "descNumber" : "ascNumber";

            //Title of Film alphabetically ordered asc/desc
            ViewBag.alphabetic = (sortOrder == "asc") ? "desc" : "asc";

            IQueryable<Movie> movies = _db.Movies;
            switch (sortOrder)
            {
                case "descNumber":
                    ViewBag.numberOrder = "ascNumber";
                    movies = movies.OrderByDescending(m => m.MovieYear);
                    break;
                case "ascNumber":
                    ViewBag.numberOrder = "descNumber";
                    movies = movies.OrderBy(m => m.MovieYear);
                    break;

                case "desc":
                    ViewBag.alphabetic = "asc";
                    movies = movies.OrderByDescending(m => m.MovieTitle);
                    break;
                case "asc":
                    ViewBag.alphabetic = "desc";
                    movies = movies.OrderBy(m => m.MovieTitle);
                    break;
            }   
            return View(movies.ToList());
        }//end Index ActionResult method


        //
        // POST: /Movie/
        [HttpGet]//action to invoke
        public ActionResult Search(string searchTerm = "")
        {
            Movie getMovie = (from d in _db.Movies
                             where d.MovieTitle.Contains(searchTerm)
                             select new Movie
                             {
                                 MovieId = d.MovieId
                             }).FirstOrDefault();
            return View("Details", getMovie.MovieId);
        }
        
        ////
        //// GET: /Movie/
        //[HttpGet]//MVC framework should find an action to invoke
        //public ActionResult Search()
        //{
        //    return Content("Search");
        //}



        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            var movies = _db.Movies.Find(id);
            return View(movies);
        }

        public PartialViewResult ActorDetails(int id)
        {
            var actors = _db.Actors.Find(id);
            return PartialView("_Details", actors);//return partial view of Actor details, to appear with Movie details
        }


        //
        // GET: /Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            try
            {   //Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var _db2 = new MoviesDbContext())
                    {
                        _db2.Movies.Add(newMovie);
                        _db2.SaveChanges();
                    }                               //sending string 'create' back to Index on creation of new Movie
                    return RedirectToAction("Index", new { toast="Create"});
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MovieList = _db.Movies.ToList();
            return View(_db.Movies.Find(id));
        }

        //
        // POST: /Home/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {
                // Find the record in the db using the Movie ID
                // Copy the edited one across to the retrieved one
                // Save back to database
                _db.Entry(editMovie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Movies.Find(id));
        }

        //
        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Movies.Remove(_db.Movies.Find(id));
            _db.SaveChanges();
            //_db.Movies.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
