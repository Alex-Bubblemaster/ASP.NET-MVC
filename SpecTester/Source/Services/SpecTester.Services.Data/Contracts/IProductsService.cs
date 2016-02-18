namespace SpecTester.Services.Data.Contracts
{
    using System.Linq;
    using SpecTester.Data.Models;
    using SpecTester.Data.Models.Common;

    public interface IProductsService
    {
        IQueryable<Product> GetAllPaging(int skip = 1, int take = 10);

        IQueryable<Product> All();

        int GetCount();

        IQueryable<Product> GetByCookingMethod(CookingMethod cookingMethod);
    }
}
