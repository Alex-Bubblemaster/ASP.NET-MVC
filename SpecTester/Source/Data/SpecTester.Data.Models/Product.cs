namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;
    using SpecTester.Common;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.CookingMethods = new HashSet<CookingMethod>();
            this.Dishes = new HashSet<Dish>();
        }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxProductNameLength)]
        public string Name { get; set; }

        // TODO: Add Image to DB as well
        public virtual ICollection<CookingMethod> CookingMethods { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
