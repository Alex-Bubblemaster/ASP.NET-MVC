﻿namespace SpecTester.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using SpecTester.Data.Models;

    public interface IDishesService
    {
        void AddDish(Dish dish);

        Dish AddProducts(int id, List<Product> products);

        Dish GetById(int id);

        Dish GetByName(string name);

        IQueryable<Dish> GetRandomDishes(int count);

        IQueryable<Dish> GetAll();

        void RemoveProductFromDish(int dishId, Product product);

        void HasSauce(int id, bool hasSauce);
    }
}