namespace Movies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int MovieId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Range(1890, 2020)]
        public int Year { get; set; }

        [MaxLength(50)]
        public string Director { get; set; }

        public virtual Actor MaleLead { get; set; }

        public virtual Actor FemaleLead { get; set; }

        public virtual Studio Studio { get; set; }

    }
}
