namespace SpecTester.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web;
    using Common;
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
