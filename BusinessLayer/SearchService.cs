using Newtonsoft.Json;
using SimonsVoss_Search.Models;

namespace SimonsVoss_Search.BusinessLayer
{
    public class SearchService: ISearchService
    {
        Data _data;
        public SearchService()
        {
            string path = @"F:\SimonsVoss-Search\Data\sv_lsm_data.json";
            var jsonContent = File.ReadAllText(path);
            _data = JsonConvert.DeserializeObject<Data>(jsonContent);
        }

        public IEnumerable<Result> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
