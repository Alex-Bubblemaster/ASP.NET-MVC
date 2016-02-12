using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Movies.Models
{
    public class MovieAddViewModel
    {
        private ICollection<ActorViewModel> femaleActors;
        private ICollection<ActorViewModel> maleActors;
        private ICollection<StudioViewModel> studios;

        public static Expression<Func<Movie, MovieAddViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieAddViewModel()
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Director = movie.Director,
                    Id = movie.MovieId,
                    maleActors = new List<ActorViewModel>(),
                    femaleActors = new List<ActorViewModel>(),
                    studios = new List<StudioViewModel>()

                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        [DisplayName("Male Leads")]
        public int SelectedMaleLeadId { get; set; }

        public ICollection<ActorViewModel> MaleActors
        {
            get { return this.maleActors; }
            set { this.maleActors = value; }
        }

        [DisplayName("Female Leads")]

        public int SelectedFemaleLeadId { get; set; }
        public ICollection<ActorViewModel> FemaleActors
        {
            get { return this.femaleActors; }
            set { this.femaleActors = value; }
        }

        [DisplayName("Studios")]

        public int  SelectedStudioId { get; set; }

        public ICollection<StudioViewModel> Studios
        {
            get { return this.studios; }
            set { this.studios = value; }
        }
    }
}