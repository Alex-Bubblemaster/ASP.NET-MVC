namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DishViewModel : IMapFrom<Dish>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public bool HasSauce { get; set; }
    }
}
