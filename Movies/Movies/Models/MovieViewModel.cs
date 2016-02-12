namespace Movies.Models
{
    using System;
    using System.Linq.Expressions;

    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieViewModel()
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Director = movie.Director,
                    StudioId = movie.Studio.Id,
                    Id = movie.MovieId
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public int? StudioId { get; set; }

    }
}