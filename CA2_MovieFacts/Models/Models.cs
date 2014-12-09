using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2_MovieFacts.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [Display (Name="Title")]
        public string MovieTitle { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int MovieYear { get; set; }
        [Required]
        [Display(Name = "Movie Facts")]
        public string MovieFacts { get; set; }

        public virtual List<ScreenName> Actors { get; set; }//Movie => ScreenName 1 to many
    }

    //A Model to store a MovieID. (Needed for the Search)
    //Can't use Movie Model to create a new object in a Linq query
    public class MovieViewModel
    {
        public int MovieId { get; set; }
    }

    //A Model to store a ActorID.(Needed for the Search)
    //Can't use Actor Model to create a new object in a Linq query
    public class ActorViewModel
    {
        public int ActorId { get; set; }
    }

    public class Actor
	{
        public int ActorId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ActorName { get; set; }
        [Required]
        [Display(Name = "Biography")]
        public string Biography { get; set; }

        public virtual List<ScreenName> Movies { get; set; }//Actor => ScreenName 1 to many
	}

    public class ScreenName
	{
        [Key, Column(Order = 0)]   // Composite key (first key)
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        [Key, Column(Order = 1)]  // Composite key (second key)
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required]
        [Display(Name = "Screen Name")]
        public string ActorScreenName { get; set; }
    }

    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ScreenName> ScreenNames { get; set; }

        public MoviesDbContext() : base ("MoviesDb") {}
    }

}