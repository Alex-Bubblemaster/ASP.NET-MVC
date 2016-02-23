namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    public class DishController : BaseController
    {
        private readonly IDishesService dishes;
        private readonly IProductsService products;

        public DishController(IDishesService dishes, IProductsService products)
        {
            this.dishes = dishes;
            this.products = products;
        }

        public ActionResult Index()
        {
            var dishes = this.dishes
                .All()
                .To<DishViewModel>()
                .ToList();
            return this.View(dishes);
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request)
        {
            var productsFromDatabase = this.products
                .All()
                .To<ProductViewModel>()
                .ToList();

            var selectedProducts = productsFromDatabase
                .Select(p => p.Id)
                .ToList();

            var model = new CreateDishViewModel()
            {
                Products = productsFromDatabase,
                SelectedProducts = selectedProducts
            };

            return this.PartialView("_CreateDish", model);
        }

        public ActionResult AddProducts([DataSourceRequest]DataSourceRequest request)
        {
            return this.PartialView("_AddProductsToDish");
        }

        [HttpPost]
        public ActionResult AddDish(CreateDishViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var productsToAddInDish = new List<Product>();
                foreach (var productId in model.SelectedProducts)
                {
                    var product = this.products.GetById(productId);
                    productsToAddInDish.Add(product);
                }

                this.dishes.AddDish(
                    new Dish()
                    {
                        Name = model.Name,
                        HasSauce = model.HasSauce,
                        Products = productsToAddInDish
                    });

                return this.RedirectToAction("Index");
            }

            return this.PartialView("_CreateDish");
        }
    }
}
