namespace Movies.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Repositories;
    using Models;

    public class StudiosController : Controller
    {
        private IRepository<Studio> studiosRepo;
        public StudiosController(IRepository<Studio> studios)
        {
            this.studiosRepo = studios;
        }

        // GET: Studios
        public ActionResult Index()
        {
            var studios = this.studiosRepo
                .All()
                .Select(StudioViewModel.FromStudio)
                .ToList();

            return this.View("Studios", studios);
        }

        public ActionResult AddStudio(StudioViewModel studio)
        {
            this.studiosRepo.Add(new Studio()
            {
                Name = studio.Name,
                Address = studio.Address
            });

            this.studiosRepo.SaveChanges();

            return this.RedirectToAction("Index");
        }

        public ActionResult DeleteStudio(int? id)
        {
            // TODO check for null
            this.studiosRepo.Delete(id);
            this.studiosRepo.SaveChanges();
            var studios = this.studiosRepo
                .All()
                .Select(StudioViewModel.FromStudio)
                .ToList();

            return this.PartialView("Studios",studios);
        }

        // GET 
        public ActionResult EditStudio(string modelName, string modelAddress, int modelId)
        {
            var model = new StudioViewModel()
            {
                Name = modelName,
                Address = modelAddress,
                Id = modelId
            };

            return this.PartialView("_PartialEditStudio", model);
        }

        [HttpPost]
        public ActionResult UpdateStudio(int id, FormCollection form)
        {
            var target = this.studiosRepo.GetById(id);
            target.Name = form["Name"];
            target.Address = form["Address"];
            this.studiosRepo.SaveChanges();

            var studios = this.studiosRepo
               .All()
               .Select(StudioViewModel.FromStudio)
               .ToList();

            return this.PartialView("Studios", studios);
        }
    }
}