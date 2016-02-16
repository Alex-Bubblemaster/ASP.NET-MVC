namespace SpecTester.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data.Contracts;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ITrainingsService trainings;

        public HomeController(ITrainingsService trainings)
        {
            this.trainings = trainings;
        }

        public ActionResult Index()
        {
            var trainingSessions = this.trainings.GetLastTen().To<TrainingViewModel>().ToList();

            return this.View(trainingSessions);
        }
    }
}
