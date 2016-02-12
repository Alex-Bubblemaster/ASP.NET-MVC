namespace Twitter.Services.DataServices.Contracts
{
    using System.Linq;
    using Models;
    public interface ITagsService
    {
        IQueryable<Tag> GetAll();

        int GetByName(string name);
    }
}
