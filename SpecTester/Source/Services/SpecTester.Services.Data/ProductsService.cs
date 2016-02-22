namespace SpecTester.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;
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

        public int GetCount()
        {
            return this.products.All().Count();
        }

        public void Add(Product entity)
        {
            this.products.Add(entity);
            this.products.Save();
        }

        public void Delete(int id)
        {
            var session = this.products.GetById(id);
            this.products.Delete(session);
            this.products.Save();
        }

        public Product GetById(int id)
        {
            var product = this.products.GetById(id);
            return product;
        }

        public void Save()
        {
            this.products.Save();
        }
    }
}
