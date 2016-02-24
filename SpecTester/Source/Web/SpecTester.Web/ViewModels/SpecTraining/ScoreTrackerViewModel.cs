namespace SpecTester.Web.ViewModels.SpecTraining
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ScoreTrackerViewModel : IMapFrom<ScoreTracker>
    {
        public string UserId { get; set; }

        //public int TrainingId { get; set; }

        public int ScoreResult { get; set; }
    }
}
