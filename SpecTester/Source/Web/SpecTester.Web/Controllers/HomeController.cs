namespace SpecTester.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using PagedList;
    using Services.Data.Contracts;
    using Services.Web;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ITrainingsService trainings;
        private readonly ICacheService cache;

        public HomeController(ITrainingsService trainings, ICacheService cache)
        {
            this.trainings = trainings;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            this.ViewBag.CurrentSort = sortOrder;
            if (page == null)
            {
                page = 1;
            }

            var trainings = this.cache
                .Get("HomePageData", () => this.trainings.All().To<TrainingViewModel>().ToList(), 5 * 60);

            // var trainings = this.trainings.All().To<TrainingViewModel>().ToList();
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return this.View(trainings.ToPagedList(pageNumber, pageSize));
        }
    }
}
