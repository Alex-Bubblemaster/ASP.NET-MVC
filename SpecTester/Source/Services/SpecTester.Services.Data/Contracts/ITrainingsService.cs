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

        IQueryable<TrainingSession> GetAllWithPaging(int skip, int take);

        TrainingSession GetById(int id);

        TrainingSession Edit(int id, string name, int totalScore, bool isDeleted);

        void Delete(int id);

        int GetCount();
    }
}
