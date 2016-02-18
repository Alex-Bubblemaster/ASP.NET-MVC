namespace SpecTester.Web.ViewModels.Common
{
    using Data.Models;
    using Data.Models.Common;
    using Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CookingMethod CookingMethod { get; set; }
    }
}
