namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
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
    public class ProductController : BaseController
    {
        private readonly IProductsService products;

        public ProductController(IProductsService products)
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var products = this.products
                .All()
                .To<ProductViewModel>()
                .ToList();

            return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request)
        {
            return this.PartialView("_CreateProduct");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, FormCollection form)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(this.Server.MapPath("~/Content/images/products/"), fileName);
                file.SaveAs(path);
                this.products.Add(
                    new Product()
                    {
                        Name = form["Name"],
                        ImageUrl = fileName
                    });
                return this.RedirectToAction("Index");
            }

            return null;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, EditProductAdminRequestModel model)
        {
            if (this.ModelState.IsValid)
            {
                var product = this.products.GetById(model.Id);
                product.Name = model.Name;
                this.products.Save();
                var responseModel = this.Mapper.Map<ProductViewModel>(product);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, ProductViewModel model)
        {
            if (model != null)
            {
                this.products.Delete(model.Id);

                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
