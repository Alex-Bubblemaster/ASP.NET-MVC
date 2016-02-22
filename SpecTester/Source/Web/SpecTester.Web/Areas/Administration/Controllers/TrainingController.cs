namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

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
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var trainingSessions = this.trainings
                .All()
                .To<TrainingAdminViewModel>()
                .ToList();

            return this.Json(trainingSessions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, TrainingAdminViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var training = this.Mapper.Map<TrainingSession>(model);
                this.trainings.Add(training);
                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, EditTrainingAdminRequestModel model)
        {
            if (this.ModelState.IsValid)
            {
                var training = this.trainings.GetById(model.Id);
                training.Name = model.Name;
                training.IsDeleted = model.IsDeleted;
                training.Name = model.Name;
                training.Score = model.Score;
                this.trainings.Save();
                var responseModel = this.Mapper.Map<TrainingAdminViewModel>(training);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, TrainingAdminViewModel model)
        {
            if (model != null)
            {
                this.trainings.Delete(model.Id);

                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}
