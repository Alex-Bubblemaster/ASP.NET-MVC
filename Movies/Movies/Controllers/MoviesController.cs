namespace Movies.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Movies.Data.Repositories;
    using Movies.Models;

    public class MoviesController : Controller
    {
        IRepository<Movie> moviesRepo;
        IRepository<Actor> actorsRepo;
        IRepository<Studio> studioRepo;

        public MoviesController(IRepository<Movie> movies, IRepository<Actor> actors, IRepository<Studio> studios)
        {
            this.moviesRepo = movies;
            this.actorsRepo = actors;
            this.studioRepo = studios;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = this.moviesRepo
               .All()
               .Select(MovieViewModel.FromMovie)
               .ToList();
             
            return this.View("Movies", movies);
        }

        public ActionResult AddMovie(MovieAddViewModel movie)
        {
            var femaleLead = this.actorsRepo.GetById(movie.SelectedFemaleLeadId);
            var maleLead = this.actorsRepo.GetById(movie.SelectedMaleLeadId);
            var studio = this.studioRepo.GetById(movie.SelectedStudioId);

            this.moviesRepo.Add(new Movie()
            {
                Title = movie.Title,
                Director = movie.Director,
                Year = movie.Year,
                FemaleLead = femaleLead,
                MaleLead = maleLead,
                Studio = studio
            });

            this.moviesRepo.SaveChanges();

            return this.RedirectToAction("Index");
        }

        // GET 
        public ActionResult EditMovie(string title, string director, int year, int id)
        {
            var model = new MovieViewModel()
            {
                Title = title,
                Director = director,
                Year = year,
                Id = id
            };

            return this.PartialView("_PartialEditMovie", model);
        }

        [HttpPost]
        public ActionResult UpdateMovie(int id, FormCollection form)
        {
            var target = this.moviesRepo.GetById(id);
            target.Title = form["Title"];
            target.Director = form["Director"];
            target.Year = int.Parse(form["Year"]);

            this.moviesRepo.SaveChanges();

            var movies = this.moviesRepo
               .All()
               .Select(MovieViewModel.FromMovie)
               .ToList();

            return this.PartialView("Movies", movies);
        }

        public ActionResult DeleteMovie(int? id)
        {
            // TODO check for null
            this.moviesRepo.Delete(id);
            this.moviesRepo.SaveChanges();
            var movies = this.moviesRepo
                .All()
                .Select(MovieViewModel.FromMovie)
                .ToList();

            return this.PartialView("Movies", movies);
        }
    }
}