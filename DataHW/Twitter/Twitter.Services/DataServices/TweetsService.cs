namespace Twitter.Services.DataServices
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class TweetsService : ITweetsService
    {
        private readonly IDbRepository<Tweet> tweets;
        private readonly IDbRepository<Tag> tags;

        public TweetsService(IDbRepository<Tweet> tweets, IDbRepository<Tag> tags)
        {
            this.tweets = tweets;
            this.tags = tags;
        }
        public IQueryable<Tweet> GetAll()
        {
            var tweets = this.tweets.All();
            return tweets;
        }

        public IQueryable<Tweet> GetByTag(string name)
        {
            var tweets = this.tweets
                              .All()
                              .Where(t => t.Tags.All(a => a.Name == name));

            return tweets;
        }

        public IQueryable<Tweet> GetByUser(string id)
        {
            var tweets = this.tweets
                              .All()
                              .Where(t => t.AuthorId == id);

            return tweets;
        }

        public void Create(Tweet tweet)
        {
            this.tweets.Add(tweet);
            this.tweets.Save();
        }

        public void Like(int id)
        {
            var tweet = this.tweets.GetById(id);
            tweet.Likes += 1;
            this.tweets.Save();
        }
    }
}
