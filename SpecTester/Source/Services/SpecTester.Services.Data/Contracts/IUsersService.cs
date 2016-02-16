namespace SpecTester.Services.Data.Contracts
{
    using System.Linq;
    using SpecTester.Data.Models;

    public interface IUsersService
    {
        User GetById(int id);

        IQueryable<User> GetTopTen();
    }
}
