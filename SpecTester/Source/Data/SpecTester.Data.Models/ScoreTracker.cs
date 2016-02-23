namespace SpecTester.Data.Models
{
    using Common.Models;

    public class ScoreTracker : BaseModel<int>
    {
        public int TrainingId { get; set; }

        public virtual TrainingSession TrainingSession { get; set; }

        public int ScoreResult { get; set; }

        public virtual User User { get; set; }

        public string UserId { get; set; }
    }
}
