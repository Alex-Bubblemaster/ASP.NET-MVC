namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Services.WebServices;
    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}