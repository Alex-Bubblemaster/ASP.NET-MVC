namespace SpecTester.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using SpecTester.Data.Models;

    public interface IUserTrainingsService
    {
        void JoinTraining(int id, string userId);

        double CompletedIn(DateTime start, DateTime finish);

        TrainingSession GetById(int id);

        void UpdateUserScore(int score, int triningId, int dishId, string userId);

        int Cook(string userId, int trainingId, int dishId, IEnumerable<int> selectedProducts);
    }
}
