namespace SpecTester.Web.Controllers
{
    using System;
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

        public ActionResult Cook(int id)
        {
            // Return the input stream to 0 as it has already been read
            this.HttpContext.Request.InputStream.Position = 0;
            var result = new System.IO.StreamReader(this.HttpContext.Request.InputStream).ReadToEnd();

            // Manually remove unnessesary chars. No need for another lib for just that, is there
            var selectedItems = result.Split(new char[] { '/', '"', '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var trainingId = int.Parse(this.Request.UrlReferrer.Segments[3]);
            var userId = this.User.Identity.GetUserId();
            int matches = this.userTrainings.Cook(userId, trainingId, id, selectedItems);

            return this.RedirectToAction("Join", new { id = id });
        }
    }
}
