namespace SpecTester.Web.ViewModels.Common
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DishNameViewModel : IMapFrom<Dish>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
