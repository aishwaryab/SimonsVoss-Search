using Newtonsoft.Json;
using SimonsVoss_Search.Models;

namespace SimonsVoss_Search.BusinessLayer
{
    public class SearchService: ISearchService
    {
        Dictionary<string, BaseEntity> _dict;
        Data _data;
        public SearchService()
        {
            string path = @"F:\SimonsVoss-Search\Data\sv_lsm_data.json";
            var jsonContent = File.ReadAllText(path);
            _data = JsonConvert.DeserializeObject<Data>(jsonContent);
            InitDictionary();
        }

        public IEnumerable<Result> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
        private void InitDictionary()
        {
            _dict = new Dictionary<string, BaseEntity>();
            foreach (var buildingItem in _data.Buildings)
            {
                _dict.Add(buildingItem.Id, buildingItem);
            }

            foreach (var lockItem in _data.Locks)
            {
                _dict.Add(lockItem.Id, lockItem);
            }

            foreach (var groupItem in _data.Groups)
            {
                _dict.Add(groupItem.Id, groupItem);
            }

            foreach (var mediumItem in _data.Media)
            {
                mediumItem.Name = mediumItem.Owner;
                _dict.Add(mediumItem.Id, mediumItem);
            }
        }
    }
}
