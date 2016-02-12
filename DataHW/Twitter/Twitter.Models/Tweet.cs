namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet: BaseModel<int>
    {
        private ICollection<Tag> tags;

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }

        [MaxLength(140)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

    }
}
