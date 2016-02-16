﻿namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels.Common;

    public class CreateDishViewModel : IMapTo<Dish>
    {
        public CreateDishViewModel()
        {
            this.CookingMethods = new List<int>();
            this.Products = new List<ProductViewModel>();
            this.PlateShapes = new List<int>();
        }

        public string Name { get; set; }

        public bool HasSauce { get; set; }

        public string SelectedPlate { get; set; }

        public IEnumerable<int> PlateShapes { get; set; }

        public string SelectedProduct { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public string SelectedCookingMethod { get; set; }

        public IEnumerable<int> CookingMethods { get; set; }
    }
}