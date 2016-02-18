namespace SpecTester.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserAdminViewModel : IMapFrom<User>
    {
        public string Email { get; set; }
    }
}
