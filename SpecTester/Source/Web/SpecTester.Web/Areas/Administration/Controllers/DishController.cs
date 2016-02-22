namespace SpecTester.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
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

        // GET: Administration/Dish
        public ActionResult Index()
        {
            var dishes = this.dishes.All().To<DishViewModel>().ToList();
            return this.View(dishes);
        }

        // GET: Administration/Dish/Details/5
        public ActionResult Details(int id)
        {
            var dish = this.dishes.GetById(id);
            if (dish == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<DishViewModel>(dish);
            return this.View(viewModel);
        }

        // GET: Administration/Dish/Create
        public ActionResult Create()
        {
            var products = this.products.All().To<ProductViewModel>().ToList();

            var model = new CreateDishViewModel()
            {
                Products = products
            };

            return this.PartialView(model);
        }

        // POST: Administration/Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Plate,HasSauce,Products")] DishViewModel dish)
        {
            if (this.ModelState.IsValid)
            {
                var dishToAdd = this.Mapper.Map<Dish>(dish);
                this.dishes.AddDish(dishToAdd);
                return this.RedirectToAction("Index");
            }

            return this.View(dish);
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
