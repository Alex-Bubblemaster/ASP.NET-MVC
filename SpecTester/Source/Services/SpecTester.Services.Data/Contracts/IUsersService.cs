namespace SpecTester.Services.Data.Contracts
{
    using System.Linq;
    using SpecTester.Data.Models;

    public interface IUsersService
    {
        User GetById(string id);

        IQueryable<User> GetTopTen();

        IQueryable<User> GetAll(int skip = 1, int take = 10);
    }
}
