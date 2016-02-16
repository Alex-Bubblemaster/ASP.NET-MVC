namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;
    using SpecTester.Common;

    public class Dish : BaseModel<int>
    {
        public Dish()
        {
            this.Products = new HashSet<Product>();
            this.Trainings = new HashSet<TrainingSession>();
        }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxDishNameLength)]
        public string Name { get; set; }

        public PlateShape Plate { get; set; }

        public bool HasSauce { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<TrainingSession> Trainings { get; set; }
    }
}
