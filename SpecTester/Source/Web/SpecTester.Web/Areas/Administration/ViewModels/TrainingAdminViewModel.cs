namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class TrainingAdminViewModel : IMapFrom<TrainingSession>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Dishes { get; set; }

        [DisplayName("Score")]
        public int Score { get; set; }

        [DisplayName("Completed In")]
        public DateTime? CompletedIn { get; set; }

        [DisplayName("Created On")]

        public DateTime? CreatedOn { get; set; }

        [DisplayName("Modified On")]

        public DateTime? ModifiedOn { get; set; }

        [DisplayName("Is Deleted")]

        public bool IsDeleted { get; set; }

        public string Author { get; set; }

        public int Users { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TrainingSession, TrainingAdminViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(p => p.Author.Email))
                .ForMember(x => x.Users, opt => opt.MapFrom(u => u.Users.Count))
                .ForMember(x => x.Dishes, opt => opt.MapFrom(d => d.Dishes.Count));
        }
    }
}
