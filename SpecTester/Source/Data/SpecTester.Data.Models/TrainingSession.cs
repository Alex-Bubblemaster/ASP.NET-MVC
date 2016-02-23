namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using SpecTester.Common;

    public class TrainingSession : BaseModel<int>
    {
        public TrainingSession()
        {
            this.Dishes = new HashSet<Dish>();
            this.Users = new HashSet<User>();
            this.ScoreTrackers = new HashSet<ScoreTracker>();
        }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxTrainingNameLength)]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }

        public int CompletedIn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<ScoreTracker> ScoreTrackers { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
