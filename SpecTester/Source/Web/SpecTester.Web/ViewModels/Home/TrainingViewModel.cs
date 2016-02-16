namespace SpecTester.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class TrainingViewModel : IMapFrom<TrainingSession>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Training/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}
