namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag : BaseModel<int>
    {
        private ICollection<Tweet> tweets;

        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        [MaxLength(140)]
        public string Name { get; set; }
    }
}
