namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateTrainingViewModel : IMapTo<TrainingSession>
    {
        public CreateTrainingViewModel()
        {
            this.Dishes = new List<DishViewModel>();
            this.SelectedDishes = new List<int>();
        }

        public string Name { get; set; }

        public int Score { get; set; }

        public IEnumerable<int> SelectedDishes { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }
    }
}
