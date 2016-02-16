namespace SpecTester.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;
    using SpecTester.Data.Models.Common;
    using Web;

    public class ProductsService : IProductsService
    {
        private readonly IDbRepository<Product> products;
        private readonly IIdentifierProvider identifierProvider;

        public ProductsService(IDbRepository<Product> products, IIdentifierProvider identifierProvider)
        {
            this.products = products;
            this.identifierProvider = identifierProvider;
        }

        public Product GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var product = this.products.GetById(intId);
            return product;
        }

        public IQueryable<Product> GetByCookingMethod(CookingMethod cookingMethod)
        {
            var products = this.products
                .All()
                .Where(p => p.CookingMethods.Contains(cookingMethod));

            return products;
        }

        public IQueryable<Product> GetAllPaging(int skip = 1, int take = 10)
        {
            var products = this.products
                .All()
                .OrderBy(p => p.Name)
                .Skip(skip * take)
                .Take(take);

            return products;
        }

        public IQueryable<Product> All()
        {
            var products = this.products
                .All()
                .OrderBy(p => p.Name);

            return products;
        }
    }
}
