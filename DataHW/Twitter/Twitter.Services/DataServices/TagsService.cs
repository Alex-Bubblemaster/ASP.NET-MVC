namespace Twitter.Services.DataServices
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Services.DataServices.Contracts;

    public class TagsService: ITagsService
    {
        private readonly IDbRepository<Tag> tags;
        private readonly IDbRepository<Tweet> tweets;

        public TagsService(IDbRepository<Tag> tags,
            IDbRepository<Tweet> tweets)
        {
            this.tags = tags;
            this.tweets = tweets;
        }
        public IQueryable<Tag> GetAll()
        {
            var tags = this.tags.All();

            return tags;
        }

        public int GetByName(string name)
        {
            var tag = this.tags.All().FirstOrDefault(t => t.Name == name);
            if(tag != null)
            {
                return tag.Id;
            }

            else
            {
                return -1;
            }
        }
    }
}
