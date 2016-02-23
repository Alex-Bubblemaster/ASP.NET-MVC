namespace SpecTester.Services.Data
{
    using System;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;

    public class UserTrainingsService : IUserTrainingsService
    {
        private readonly IDbRepository<User> users;
        private readonly IDbRepository<TrainingSession> trainings;

        public UserTrainingsService(IDbRepository<User> users, IDbRepository<TrainingSession> trainings)
        {
            this.users = users;
            this.trainings = trainings;
        }

        public void JoinTraining(int id, string userId)
        {
            var targetTraining = this.trainings.GetById(id);
            var user = this.users.GetById(userId);

            if (!targetTraining.Users.Contains(user))
            {
                user.TrainingSessions.Add(targetTraining);
                targetTraining.Users.Add(user);
                this.trainings.Save();
                this.users.Save();
            }
        }

        public double CompletedIn(DateTime start, DateTime finish)
        {
            var completedIn = finish.Subtract(start);

            if (completedIn.TotalHours > 1)
            {
                return 60;
            }
            else
            {
                return completedIn.TotalSeconds;
            }
        }

        public TrainingSession GetById(int id)
        {
            return this.trainings.GetById(id);
        }
    }
}
