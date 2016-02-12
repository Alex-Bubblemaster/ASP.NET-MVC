namespace Movies.Controllers
{
    using Movies.Data.Repositories;
    using Movies.Models;
    using System.Web.Mvc;
    using System.Linq;
    public class HomeController : Controller
    {

        IRepository<Actor> actorsRepo;
        IRepository<Movie> moviesRepo;
        IRepository<Studio> studiosRepo;
        public HomeController(IRepository<Actor> actors, IRepository<Movie> movies, IRepository<Studio> studios)
        {
            this.actorsRepo = actors;
            this.moviesRepo = movies;
            this.studiosRepo = studios;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddActor()
        {
            return View("_PartialAddActor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddActor(ActorViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.actorsRepo.Add(new Actor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    IsFemale = model.IsFemale
                });
                this.actorsRepo.SaveChanges();
                return this.Redirect("/Actors");
            }

            else
            {
                return this.PartialView("Error");
            }
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            var femaleActors = this.actorsRepo
                .All()
                .Select(ActorViewModel.FromActor)
                .Where(a => a.IsFemale)
                .ToList();

            var maleActors = this.actorsRepo
                .All()
                .Select(ActorViewModel.FromActor)
                .Where(a => !a.IsFemale)
                .ToList();

            var studios = this.studiosRepo
                .All()
                .Select(StudioViewModel.FromStudio)
                .ToList();

            var model = new MovieAddViewModel()
            {
                FemaleActors = femaleActors,
                MaleActors = maleActors,
                Studios = studios
            };

            return View("_PartialAddMovie", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("AddMovie", "Movies", model);
            }

            else
            {
                return this.PartialView("Error");
            }
        }

        [HttpGet]
        public ActionResult AddStudio()
        {
            return View("_PartialAddStudio");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudio(StudioViewModel model)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("AddStudio", "Studios", model);
            }

            else
            {
                return this.PartialView("Error");
            }
        }
    }
}