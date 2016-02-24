namespace SpecTester.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using SpecTester.Data.Models;

    public interface ITrainingsService
    {
        void Add(TrainingSession session);

        TrainingSession AddDishes(int id, List<Dish> dishes);

        TrainingSession RemoveDish(int id, Dish dish);

        IQueryable<TrainingSession> GetLastTen();

        IQueryable<TrainingSession> All();

        TrainingSession GetById(int id);

        void Save();

        void Delete(int id);

        int GetCount();
    }
}
