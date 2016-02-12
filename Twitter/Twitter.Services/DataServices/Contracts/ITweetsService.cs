using System.Linq;
namespace Twitter.Services.DataServices.Contracts
{
    using Models;

    public interface ITweetsService
    {
        void Create(Tweet tweet);

        void Like(int id);

        IQueryable<Tweet> GetAll();

        IQueryable<Tweet> GetByUser(string id);

        IQueryable<Tweet> GetByTag(string name);

    }
}
