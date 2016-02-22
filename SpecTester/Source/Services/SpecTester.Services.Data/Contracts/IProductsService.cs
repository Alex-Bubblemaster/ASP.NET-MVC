namespace SpecTester.Services.Data.Contracts
{
    using System.Linq;
    using SpecTester.Data.Models;

    public interface IProductsService
    {
        IQueryable<Product> GetAllPaging(int skip = 1, int take = 10);

        IQueryable<Product> All();

        void Add(Product entity);

        void Delete(int id);

        Product GetById(int id);

        void Save();

        int GetCount();
    }
}
