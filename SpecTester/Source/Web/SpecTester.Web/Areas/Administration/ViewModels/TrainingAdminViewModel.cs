namespace SpecTester.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using AutoMapper;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class TrainingAdminViewModel : IMapFrom<TrainingSession>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }

        [DisplayName("Total Score")]
        public int TotalScore { get; set; }

        [DisplayName("Completed In")]
        public DateTime? CompletedIn { get; set; }

        [DisplayName("Created On")]

        public DateTime? CreatedOn { get; set; }

        [DisplayName("Modified On")]

        public DateTime? ModifiedOn { get; set; }

        [DisplayName("Is Deleted")]

        public bool IsDeleted { get; set; }

        public string Author { get; set; }

        public IEnumerable<UserAdminViewModel> Users { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TrainingSession, TrainingAdminViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(p => p.Author.Email));
        }
    }
}
