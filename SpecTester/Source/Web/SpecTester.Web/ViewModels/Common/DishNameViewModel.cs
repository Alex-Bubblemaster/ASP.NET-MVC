namespace SpecTester.Web.ViewModels.Common
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DishNameViewModel : IMapFrom<Dish>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
