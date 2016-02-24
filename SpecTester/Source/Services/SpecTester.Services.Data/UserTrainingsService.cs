namespace SpecTester.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public int Cook(string userId, int trainingId, int dishId, IEnumerable<int> selectedProducts)
        {
            int matches = 0;
            var training = this.trainings.GetById(trainingId);
            if (training != null)
            {
                var dish = training.Dishes.FirstOrDefault(x => x.Id == dishId);
                if (dish != null)
                {
                    foreach (var product in dish.Products)
                    {
                        foreach (var item in selectedProducts)
                        {
                            if (product.Id == item)
                            {
                                matches++;
                            }
                        }
                    }
                }
            }

            this.UpdateUserScore(matches, trainingId, userId);
            return matches;
        }

        public void UpdateUserScore(int score, int trainingId, string userId)
        {
            var user = this.users.GetById(userId);
            var training = this.trainings.GetById(trainingId);
            var userScoreTracker = user.ScoreTrackers.FirstOrDefault(x => x.TrainingId == trainingId);
            if (userScoreTracker != null && score > userScoreTracker.ScoreResult)
            {
                userScoreTracker.ScoreResult = score;
            }
            else
            {
                user.ScoreTrackers.Add(new ScoreTracker()
                {
                    ScoreResult = score,
                    UserId = userId,
                    User = user,
                    TrainingId = trainingId,
                    TrainingSession = training
                });
            }

            this.users.Save();
        }
    }
}
