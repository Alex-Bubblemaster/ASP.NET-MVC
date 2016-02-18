namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Areas.Administration.ViewModels;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditTrainingAdminRequestModel : IMapFrom<TrainingSession>
    {
        public string Name { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }

        [DisplayName("Total Score")]
        public int TotalScore { get; set; }

        public bool IsDeleted { get; set; }
    }
}
