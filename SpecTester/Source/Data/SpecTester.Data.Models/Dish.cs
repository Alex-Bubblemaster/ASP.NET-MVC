namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using Data.Common.Models;

    public class Dish : BaseModel<int>
    {
        public Dish()
        {
            this.Products = new HashSet<Product>();
            this.Trainings = new HashSet<TrainingSession>();
        }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public PlateShape Plate { get; set; }

        public bool HasSauce { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<TrainingSession> Trainings { get; set; }
    }
}
