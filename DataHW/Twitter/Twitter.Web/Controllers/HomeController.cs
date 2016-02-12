namespace Twitter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.DataServices.Contracts;

    public class HomeController : BaseController
    {
        private readonly ITweetsService tweets;
        private readonly ITagsService tags;

        public HomeController(ITweetsService tweets, ITagsService tags)
        {
            this.tweets = tweets;
            this.tags = tags;
        }

        public ActionResult Index()
        {
            
            var tweets = this.tweets
                                .GetAll()
                                //.Select(TweetViewModel.FromTweet)
                                .ToList();

            return View("Index", tweets);
        }

        public ActionResult Search(FormCollection tag)
        {
            var tagToFind = tag["query"];
            var result = this.tweets.GetByTag(tagToFind).ToList();

            return this.PartialView("Index", result);
        }
    }
}