namespace SpecTester.Web.ViewModels.Common
{
    using System.Collections.Generic;
    using Data.Models;
    using Data.Models.Common;
    using Infrastructure.Mapping;

    public class DishViewModel : IMapFrom<Dish>
    {
        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public PlateShape Plate { get; set; }

        public bool HasSauce { get; set; }
    }
}
