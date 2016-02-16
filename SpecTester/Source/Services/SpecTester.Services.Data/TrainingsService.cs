namespace SpecTester.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SpecTester.Data.Common;
    using SpecTester.Data.Models;
    using Web;

    public class TrainingsService : ITrainingsService
    {
        private readonly IDbRepository<TrainingSession> trainings;
        private readonly IIdentifierProvider identifierProvider;

        public TrainingsService(IDbRepository<TrainingSession> trainings, IIdentifierProvider identifierProvider)
        {
            this.trainings = trainings;
            this.identifierProvider = identifierProvider;
        }

        public TrainingSession AddDishes(int id, List<Dish> dishes)
        {
            var training = this.trainings.GetById(id);
            foreach (var dish in dishes)
            {
                training.Dishes.Add(dish);
            }

            this.trainings.Save();
            return training;
        }

        public TrainingSession RemoveDish(int id, Dish dish)
        {
            var training = this.trainings.GetById(id);
            training.Dishes.Remove(dish);
            this.trainings.Save();

            return training;
        }

        public IQueryable<TrainingSession> GetLastTen()
        {
            var latestTen = this.trainings.All().OrderBy(x => x.ModifiedOn).Take(10);
            return latestTen;
        }

        public IQueryable<TrainingSession> All()
        {
            var trainings = this.trainings
                .All()
                .OrderBy(x => x.Name);

            return trainings;
        }

        public IQueryable<TrainingSession> GetAllWithPaging(int skip = 1, int take = 10)
        {
            var trainings = this.trainings
                .All()
                .OrderBy(x => x.Name)
                .Skip(skip * take)
                .Take(take);

            return trainings;
        }

        public TrainingSession GetById(int id)
        {
            var session = this.trainings.GetById(id);
            return session;
        }

        public void Add(TrainingSession session)
        {
            this.trainings.Add(session);
            this.trainings.Save();
        }

        // TODO check is admin
        public TrainingSession Edit(int id, string name, int totalScore, bool isDeleted)
        {
            var sessionToEdit = this.trainings.GetById(id);

            if (sessionToEdit == null)
            {
                return null;
            }

            sessionToEdit.Name = name;
            sessionToEdit.TotalScore = totalScore;
            sessionToEdit.IsDeleted = isDeleted;
            this.trainings.Save();

            return sessionToEdit;
        }

        public void Delete(int id)
        {
            var session = this.trainings.GetById(id);
            this.trainings.Delete(session);
            this.trainings.Save();
        }
    }
}
