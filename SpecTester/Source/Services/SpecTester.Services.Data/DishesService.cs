namespace SpecTester.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;
    using Web;

    public class DishesService : IDishesService
    {
        private readonly IDbRepository<Dish> dishes;
        private readonly IDbRepository<Product> products;
        private readonly IIdentifierProvider identifierProvider;

        public DishesService(IDbRepository<Dish> dishes, IDbRepository<Product> products, IIdentifierProvider identifierProvider)
        {
            this.dishes = dishes;
            this.products = products;
            this.identifierProvider = identifierProvider;
        }

        public void AddDish(Dish dish)
        {
            this.dishes.Add(dish);
            this.dishes.Save();
        }

        public Dish GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var dish = this.dishes.GetById(intId);
            return dish;
        }

        public IQueryable<Dish> GetRandomDishes(int count)
        {
            return this.dishes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public Dish GetByName(string name)
        {
            // TODO: Check creation
            var dish = this.dishes.All().FirstOrDefault(x => x.Name == name);
            if (dish != null)
            {
                return dish;
            }

            dish = new Dish { Name = name };
            this.dishes.Add(dish);
            this.dishes.Save();
            return dish;
        }

        public Dish GetById(int id)
        {
            var dish = this.dishes.All().FirstOrDefault(x => x.Id == id);
            return dish;
        }

        public IQueryable<Dish> GetAllPaging(int skip = 1, int take = 10)
        {
            return this.dishes
                .All()
                .OrderBy(x => x.Name)
                .Skip(skip * take)
                .Take(take);
        }

        public IQueryable<Dish> All()
        {
            return this.dishes
                .All()
                .OrderBy(x => x.Name);
        }

        public Dish AddProducts(int id, List<int> products)
        {
            var dish = this.dishes.GetById(id);
            foreach (var productId in products)
            {
                var product = this.products.GetById(productId);
                dish.Products.Add(product);
            }

            this.dishes.Save();
            return dish;
        }

        public void RemoveProductFromDish(int dishId, Product product)
        {
            var dish = this.dishes.GetById(dishId);
            dish.Products.Remove(product);
            this.dishes.Save();
        }

        public void HasSauce(int id, bool hasSauce)
        {
            var dish = this.dishes.GetById(id);
            dish.HasSauce = hasSauce;
            this.dishes.Save();
        }

        public int GetCount()
        {
            return this.dishes.All().Count();
        }
    }
}
