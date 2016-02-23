namespace SpecTester.Services.Data.Contracts
{
    using System;
    using SpecTester.Data.Models;
    public interface IUserTrainingsService
    {
        void JoinTraining(int id, string userId);

        double CompletedIn(DateTime start, DateTime finish);

        TrainingSession GetById(int id);
    }
}
