using SimonsVoss_Search.Models;

namespace SimonsVoss_Search.BusinessLayer
{
    public interface ISearchService
    {
        IEnumerable<Result> Search(string searchTerm);
    }
}
