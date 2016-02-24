namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateDishViewModel : IMapTo<Dish>
    {
        public CreateDishViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.SelectedProducts = new List<int>();
        }

        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MaxDishNameLength)]
        public string Name { get; set; }

        public bool HasSauce { get; set; }

        [Required]
        public IEnumerable<int> SelectedProducts { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
