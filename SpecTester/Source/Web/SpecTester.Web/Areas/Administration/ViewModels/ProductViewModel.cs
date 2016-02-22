namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

    }
}
