namespace SpecTester.Data.Models
{
    using System.Collections.Generic;
    using Common;
    using Data.Common.Models;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.CookingMethods = new HashSet<CookingMethod>();
            this.Dishes = new HashSet<Dish>();
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public virtual ICollection<CookingMethod> CookingMethods { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

    }
}
