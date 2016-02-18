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

        public ActionResult ReadTraining([DataSourceRequest]DataSourceRequest request)
        {
            var trainingSessions = this.trainings
                .All()
                .To<TrainingAdminViewModel>()
                .ToList();

            return this.Json(trainingSessions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateTraining([DataSourceRequest]DataSourceRequest request, TrainingAdminViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var training = this.Mapper.Map<TrainingSession>(model);
                this.trainings.Add(training);
                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult UpdateTraining([DataSourceRequest]DataSourceRequest request, TrainingAdminViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var training = this.trainings.GetById(model.Id);
                this.Mapper.Map(model, training);
                this.trainings.Edit(training.Id, training.Name, training.Score, training.IsDeleted);
                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult DeleteGift([DataSourceRequest] DataSourceRequest request, TrainingAdminViewModel model)
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
