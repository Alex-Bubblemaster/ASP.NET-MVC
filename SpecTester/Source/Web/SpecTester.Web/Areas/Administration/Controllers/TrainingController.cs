namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class TrainingController : BaseController
    {
        private readonly ITrainingsService trainings;
        private readonly IUsersService users;
        private readonly IDishesService dishes;

        public TrainingController(ITrainingsService trainings, IUsersService users, IDishesService dishes)
        {
            this.trainings = trainings;
            this.users = users;
            this.dishes = dishes;
        }

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

        public ActionResult AddTraining([DataSourceRequest]DataSourceRequest request)
        {
            var dishesFromDatabase = this.dishes
                .All()
                .To<DishViewModel>()
                .ToList();

            var selectedDishes = dishesFromDatabase
                .Select(d => d.Id)
                .ToList();

            var model = new CreateTrainingViewModel()
            {
                Dishes = dishesFromDatabase,
                SelectedDishes = selectedDishes
            };
            return this.PartialView("_CreateTraining", model);
        }

        [HttpPost]
        public ActionResult Create(CreateTrainingViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var dishesToAddInTraining = new List<Dish>();
                var authorId = this.User.Identity.GetUserId();
                var author = this.users.GetById(authorId);

                foreach (var dishId in model.SelectedDishes)
                {
                    var dish = this.dishes.GetById(dishId);
                    dishesToAddInTraining.Add(dish);
                }

                this.trainings.Add(
                    new TrainingSession()
                    {
                        Name = model.Name,
                        Dishes = dishesToAddInTraining,
                        Score = model.Score,
                        Author = author,
                        AuthorId = authorId
                    });

                return this.RedirectToAction("Index");
            }

            return this.PartialView("_CreateTraining");
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
