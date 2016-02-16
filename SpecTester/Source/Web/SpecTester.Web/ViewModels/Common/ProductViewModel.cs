namespace SpecTester.Web.ViewModels.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Common;
    using Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product> // IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        //public IEnumerable<int> CookingMethods { get; set; }

        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    configuration.CreateMap<Product, ProductViewModel>()
        //        .ForMember(x => x.CookingMethods, opt => opt.MapFrom(m => m.CookingMethods));
        //}
    }
}
