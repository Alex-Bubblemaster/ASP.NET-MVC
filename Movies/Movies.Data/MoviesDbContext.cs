namespace Movies.Data
{
    using System.Data.Entity;
    using Models;

    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Actor> Actors { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Studio> Studios { get; set; }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }
    }
}