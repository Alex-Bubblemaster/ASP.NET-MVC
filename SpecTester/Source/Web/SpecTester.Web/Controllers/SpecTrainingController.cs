namespace SpecTester.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Areas.Administration.ViewModels;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Home;

    [Authorize]
    public class SpecTrainingController : BaseController
    {
        private readonly IUserTrainingsService userTrainings;
        private readonly IProductsService products;

        public SpecTrainingController(IUserTrainingsService userTrainings, IProductsService products)
        {
            this.userTrainings = userTrainings;
            this.products = products;
        }

        public ActionResult Join(int id)
        {
            string userId = this.User.Identity.GetUserId();
            this.userTrainings.JoinTraining(id, userId);
            var training = this.userTrainings.GetById(id);

            if (training != null)
            {
                var model = this.Mapper.Map<TrainingViewModel>(training);
                return this.PartialView("_TrainingDetail", model);
            }

            // TODO: add 404
            return null;
        }

        public ActionResult GetProducts()
        {
            var products = this.products
                .All()
                .To<ProductViewModel>()
                .ToList();

            return this.PartialView("_ProductForCooking", products);
        }

        // GET: SpecTraining/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecTraining/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpecTraining/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecTraining/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpecTraining/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
