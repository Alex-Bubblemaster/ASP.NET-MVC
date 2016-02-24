namespace SpecTester.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ViewResult Index()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}
