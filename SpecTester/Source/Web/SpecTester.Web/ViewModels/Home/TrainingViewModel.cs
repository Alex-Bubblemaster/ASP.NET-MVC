namespace SpecTester.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using Areas.Administration.ViewModels;
    using AutoMapper;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;
    using SpecTraining;

    public class TrainingViewModel : IMapFrom<TrainingSession>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DishNameViewModel> Dishes { get; set; }

        public IEnumerable<CreateDishViewModel> CreateDishes { get; set; }

        public IEnumerable<ScoreTrackerViewModel> ScoreTrackers { get; set; }

        public int Users { get; set; }

        public int Score { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Training/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TrainingSession, TrainingViewModel>()
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users.Count))
                .ForMember(x => x.CreateDishes, opt => opt.Ignore());
        }
    }
}
