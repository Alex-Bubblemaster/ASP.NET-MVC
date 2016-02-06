namespace BitCalculator.Controllers
{
    using Models;
    using System.Collections.Generic;
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int quantity = 1,  int kilo = 1024, double type = 0.125)
        {
           
            ViewBag.SelectedType = type;
            ViewBag.SelectedKilo = kilo;
            ViewBag.Quantity = quantity;

            var allTypes = ConversionTypeMultiples.All(kilo);
            
            return View(allTypes);
        }
    }
}