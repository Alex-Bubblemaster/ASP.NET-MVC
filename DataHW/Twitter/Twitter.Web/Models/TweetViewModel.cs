namespace Twitter.Web.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;
    public class TweetViewModel
    {
        private ICollection<TagViewModel> tags { get; set; }
        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel()
                {
                    Id = tweet.Id,
                    Author = tweet.Author.UserName,
                    CreatedOn = tweet.CreatedOn,
                    Likes = tweet.Likes,
                    Content = tweet.Content,
                    Tags = new List<TagViewModel>()
                };
            }
        }

        public int Likes { get; set; }

        public ICollection<TagViewModel> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public int Id { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

    }
}