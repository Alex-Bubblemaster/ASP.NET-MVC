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

        [HttpGet]
        public ActionResult Index(int? page)
        {
            int toSkip = 0;
            int toTake = 5;

            if (page != null)
            {
                toSkip = int.Parse(page.ToString());
            }

            var trainingSessions = this.trainings
                .GetAllWithPaging(toSkip, toTake)
                .To<TrainingViewModel>()
                .ToList();

            this.ViewBag.Pages = trainingSessions.Count / toTake;
            this.ViewBag.CurrentPage = toSkip;

            return this.View(trainingSessions);
        }
    }
}
