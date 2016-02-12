namespace Twitter.Web.Controllers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using Models;
    using Services.DataServices.Contracts;
    using Twitter.Models;

    [Authorize]
    public class TweetController : BaseController
    {
        private readonly ITweetsService tweets;

        public TweetController(ITweetsService tweets)
        {
            this.tweets = tweets;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("_PartialAddTweet");
        }

        [HttpPost]
        public ActionResult Create(TweetViewModel tweet)
        {
            var tagsMatches = Regex.Matches(tweet.Content, @"(#[a-zA-Z_\d-]+)");
            var tags = new List<Tag>();

            foreach (Match tag in tagsMatches)
            {
                tags.Add(new Tag()
                {
                    Name = tag.Value
                });
            }

            var userId = User.Identity.GetUserId();

            var newTweet = new Tweet()
            {
                AuthorId = userId,
                Content = tweet.Content,
                Tags = tags
            };

            this.tweets.Create(newTweet);

            return this.RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Like(int id)
        {
            this.tweets.Like(id);

            return this.RedirectToAction("Index", "Home");

        }
    }
}