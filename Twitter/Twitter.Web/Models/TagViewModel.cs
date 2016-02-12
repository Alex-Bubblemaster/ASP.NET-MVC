namespace Twitter.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Twitter.Models;
    public class TagViewModel
    {
        private ICollection<TweetViewModel> tweets { get; set; }

        public static Expression<Func<Tag, TagViewModel>> FromTag
        {
            get
            {
                return tag => new TagViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Tweets = new List<TweetViewModel>()
                };
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TweetViewModel> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

    }
}