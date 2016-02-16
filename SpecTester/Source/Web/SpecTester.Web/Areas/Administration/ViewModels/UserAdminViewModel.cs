namespace SpecTester.Web.ViewModels.Admin
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserAdminViewModel : IMapFrom<User>
    {
        public string Email { get; set; }
    }
}
