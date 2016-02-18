namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
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
        //public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = new Product
        //        {
        //            Name = product.Name,
        //            DeletedOn = product.DeletedOn,
        //            CookingMethods = product.CookingMethods
        //        };

        //        db.Products.Add(entity);
        //        db.SaveChanges();
        //        product.Id = entity.Id;
        //    }

        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = new Product
        //        {
        //            Id = product.Id,
        //            Name = product.Name,
        //            CookingMethods = product.CookingMethods
        //        };

        //        db.Products.Attach(entity);
        //        db.Entry(entity).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }

        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    CookingMethods = product.CookingMethods
                };

                //db.Products.Attach(entity);
                //db.Products.Remove(entity);
                //db.SaveChanges();
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}
