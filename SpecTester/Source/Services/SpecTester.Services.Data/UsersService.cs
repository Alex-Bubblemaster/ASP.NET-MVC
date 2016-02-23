namespace SpecTester.Services.Data
{
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;
        private readonly IDbRepository<TrainingSession> trainings;

        public UsersService(IDbRepository<User> users, IDbRepository<TrainingSession> trainings)
        {
            this.users = users;
            this.trainings = trainings;
        }

        public User GetById(string id)
        {
            var user = this.users.GetById(id);

            return user;
        }

        public IQueryable<User> GetTopTen()
        {
            var topTen = this.users
                .All()
                .OrderByDescending(x => x.TotalScore)
                .Take(10);

            return topTen;
        }

        public IQueryable<User> GetAll(int skip = 1, int take = 10)
        {
            var users = this.users
                .All()
                .OrderBy(x => x.Email)
                .Skip(skip * take)
                .Take(take);

            return users;
        }
    }
}
