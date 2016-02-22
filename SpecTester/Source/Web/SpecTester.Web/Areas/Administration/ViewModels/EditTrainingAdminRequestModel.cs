namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditTrainingAdminRequestModel : IMapFrom<TrainingSession>
    {
        public string Name { get; set; }

        public string AuthorId { get; set; }

        public int Id { get; set; }

        [DisplayName("Total Score")]
        public int Score { get; set; }

        public bool IsDeleted { get; set; }
    }
}
