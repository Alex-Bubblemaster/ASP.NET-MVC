namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageController : BaseController
    {
        // TODO: add IUsersService
        private readonly IProductsService products;
        private readonly ITrainingsService trainings;
        private readonly IDishesService dishes;

        public ManageController(IProductsService products, ITrainingsService trainings, IDishesService dishes)
        {
            this.products = products;
            this.trainings = trainings;
            this.dishes = dishes;
        }

        // GET: Administration/Manage
        [HttpGet]
        public ActionResult Index()
        {
            var productsCount = this.products.GetCount();
            var trainingsCount = this.trainings.GetCount();
            var dishesCount = this.dishes.GetCount();

            var model = new AdminManageViewModel()
            {
                Trainings = trainingsCount,
                Products = productsCount,
                Dishes = dishesCount
            };

            return this.View(model);
        }
    }
}
