namespace SpecTester.Web.ViewModels.Common
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DishNameViewModel : IMapFrom<Dish>
    {
        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public bool HasSauce { get; set; }
    }
}
