namespace SpecTester.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Common.Models;

    public class TrainingSession : BaseModel<int>
    {
        public TrainingSession()
        {
            this.Dishes = new HashSet<Dish>();
            this.Users = new HashSet<User>();
        }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int TotalScore { get; set; }

        public DateTime? CompletedIn { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
