namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels.Common;

    public class CreateDishViewModel : IMapTo<Dish>
    {
        public CreateDishViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.SelectedProducts = new List<int>();
        }

        public string Name { get; set; }

        public bool HasSauce { get; set; }

        public IEnumerable<int> SelectedProducts { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
