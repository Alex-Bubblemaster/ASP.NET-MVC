namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SpecTester.Common;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.Dishes = new HashSet<Dish>();
        }

        public string ImageUrl { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxProductNameLength)]
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
