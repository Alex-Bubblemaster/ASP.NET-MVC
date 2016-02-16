namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Web.Controllers;
    using Web.ViewModels.Admin;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class TrainingController : BaseController
    {
        private readonly ITrainingsService trainings;
        private readonly IUsersService users;

        public TrainingController(ITrainingsService trainings, IUsersService users)
        {
            this.trainings = trainings;
            this.users = users;
        }

        // GET: Administration/Training
        public ActionResult Index()
        {
            var trainingSessions = this.trainings.All().To<TrainingAdminViewModel>().ToList();
            return this.View(trainingSessions);
        }

        // GET: Administration/Training/Details/5
        public ActionResult Details(int id)
        {
            var trainingSession = this.trainings.GetById(id);
            if (trainingSession == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<TrainingAdminViewModel>(trainingSession);
            return this.View(trainingSession);
        }

        // GET: Administration/Training/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Training/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,TotalScore")] TrainingSession trainingSession)
        {
            if (this.ModelState.IsValid)
            {
                trainingSession.AuthorId = this.HttpContext.User.Identity.GetUserId();
                this.trainings.Add(trainingSession);
                return this.RedirectToAction("Index");
            }

            var viewModel = this.Mapper.Map<TrainingAdminViewModel>(trainingSession);
            return this.View(viewModel);
        }

        // GET: Administration/Training/Edit/5
        public ActionResult Edit(int id)
        {
            var trainingSession = this.trainings.GetById(id);
            if (trainingSession == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<TrainingAdminViewModel>(trainingSession);
            return this.View(viewModel);
        }

        // POST: Administration/Training/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TotalScore,IsDeleted")] TrainingSession session)
        {
            if (this.ModelState.IsValid)
            {
                this.trainings.Edit(session.Id, session.Name, session.TotalScore, session.IsDeleted);
                return this.RedirectToAction("Index");
            }

            var viewModel = this.Mapper.Map<TrainingAdminViewModel>(session);
            return this.View(viewModel);
        }

        // GET: Administration/Training/Delete/5
        public ActionResult Delete(int id)
        {
            var trainingSession = this.trainings.GetById(id);
            if (trainingSession == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<TrainingAdminViewModel>(trainingSession);
            return this.View(viewModel);
        }

        // POST: Administration/Training/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.trainings.Delete(id);
            return this.RedirectToAction("Index");
        }
    }
}
