namespace SpecTester.Services.Data.Contracts
{
    using System.Linq;
    using SpecTester.Data.Models;
    using SpecTester.Data.Models.Common;

    public interface IProductsService
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetByCookingMethod(CookingMethod cookingMethod);
    }
}
