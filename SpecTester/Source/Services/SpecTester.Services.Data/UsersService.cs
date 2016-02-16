namespace SpecTester.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public User GetById(int id)
        {
            var user = this.users.GetById(id);

            return user;
        }

        public IQueryable<User> GetTopTen()
        {
            // throw new NotImplementedException();
            return null;
        }
    }
}
