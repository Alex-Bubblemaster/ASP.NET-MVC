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

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult AddProductsToDish([DataSourceRequest]DataSourceRequest request, IEnumerable<int> products, int id)
        //{
        //    var dish = this.dishes.AddProducts(id, products.ToList());

        //    if (dish != null)
        //    {
        //        var responseModel = this.Mapper.Map<DishViewModel>(dish);
        //        return this.Json(new[] { responseModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //    }

        //    return null;
        //}

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

        //// GET: Administration/Dish/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Dish dish = db.Dishes.Find(id);
        //    if (dish == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PlateId = new SelectList(db.Plates, "Id", "Id", dish.PlateId);
        //    return View(dish);
        //}

        //// POST: Administration/Dish/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,PlateId,HasSauce,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Dish dish)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dish).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PlateId = new SelectList(db.Plates, "Id", "Id", dish.PlateId);
        //    return View(dish);
        //}

        //// GET: Administration/Dish/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Dish dish = db.Dishes.Find(id);
        //    if (dish == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dish);
        //}

        //// POST: Administration/Dish/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Dish dish = db.Dishes.Find(id);
        //    db.Dishes.Remove(dish);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
