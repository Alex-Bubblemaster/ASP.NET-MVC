namespace SpecTester.Web.ViewModels.Common
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DishNameViewModel : IMapFrom<Dish>
    {
        public string Name { get; set; }
    }
}