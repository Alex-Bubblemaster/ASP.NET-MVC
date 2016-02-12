namespace Movies.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Movies.Data.Repositories;
    using Movies.Models;

    public class ActorsController : Controller
    {
        IRepository<Actor> actorsRepo;

        public ActorsController(IRepository<Actor> actors)
        {
            this.actorsRepo = actors;
        }

        // GET: Actors
        public ActionResult Index()
        {
            var actors = this.actorsRepo
                .All()
                .Select(ActorViewModel.FromActor)
                .ToList();

            return View("Actors", actors);
        }
        public ActionResult EditActor(string firstName, string lastName, DateTime dob, int id, bool gender)
        {
            var model = new ActorViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dob,
                IsFemale = gender,
                Id = id
            };

            return this.PartialView("_PartialEditActor", model);
        }

        [HttpPost]
        public ActionResult UpdateActor(int id, FormCollection form)
        {
            var target = this.actorsRepo.GetById(id);
            target.FirstName = form["FirstName"];
            target.LastName = form["LastName"];
            target.DOB = DateTime.Parse(form["DOB"]);
            target.IsFemale = bool.Parse(form["IsFemale"]);

            this.actorsRepo.SaveChanges();

            var actors = this.actorsRepo
               .All()
               .Select(ActorViewModel.FromActor)
               .ToList();

            return this.PartialView("Actors", actors);
        }

        public ActionResult DeleteActor(int? id)
        {
            // TODO check for null
            this.actorsRepo.Delete(id);
            this.actorsRepo.SaveChanges();

            var actors = this.actorsRepo
                .All()
                .Select(ActorViewModel.FromActor)
                .ToList();

            return this.PartialView("Actors", actors);
        }
    }
}
