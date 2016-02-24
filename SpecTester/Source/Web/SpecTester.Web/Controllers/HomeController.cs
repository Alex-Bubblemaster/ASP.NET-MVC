namespace SpecTester.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using PagedList;
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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            this.ViewBag.CurrentSort = sortOrder;
            page = 1;
            var trainingSessions = this.trainings
                .All()
                .To<TrainingViewModel>()
                .ToList();

            int pageSize = 3;
            int pageNumber = page ?? 1;
            return this.View(trainingSessions.ToPagedList(pageNumber, pageSize));
        }
    }
}
