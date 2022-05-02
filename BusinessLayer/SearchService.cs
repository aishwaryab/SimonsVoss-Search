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
            if (jsonContent != null)
                _data = JsonConvert.DeserializeObject<Data>(jsonContent);
            InitDictionary();
        }

        public IEnumerable<Result> Search(string searchTerm)
        {
            var resultsLookUp = new Dictionary<string, Result>();
            foreach (var building in _data.Buildings)
            {
                int weight = building.FindSearchTermWeight(searchTerm);
                ValidateAndPopulateResult(building, weight, resultsLookUp);
            }

            foreach (var lockInfo in _data.Locks)
            {
                int weight = lockInfo.FindSearchTermWeight(searchTerm);
                ValidateAndPopulateResult(lockInfo, weight, resultsLookUp);

                if (_dict.ContainsKey(lockInfo.BuildingId))
                {
                    var buildingInfo = _dict[lockInfo.BuildingId];
                    weight = buildingInfo.FindSearchTermWeight(searchTerm, true);
                    ValidateAndPopulateResult(buildingInfo, weight, resultsLookUp);
                }
            }

            foreach (var group in _data.Groups)
            {
                int weight = group.FindSearchTermWeight(searchTerm);
                ValidateAndPopulateResult(group, weight, resultsLookUp);
            }

            foreach (var medium in _data.Media)
            {
                int weight = medium.FindSearchTermWeight(searchTerm);
                ValidateAndPopulateResult(medium, weight, resultsLookUp);

                if (_dict.ContainsKey(medium.GroupId))
                {
                    var groupInfo = _dict[medium.GroupId];
                    weight = groupInfo.FindSearchTermWeight(searchTerm, true);
                    ValidateAndPopulateResult(groupInfo, weight, resultsLookUp);
                }
            }

            return resultsLookUp.Values.OrderByDescending(x => x.Weight);
        }

        private void ValidateAndPopulateResult(BaseEntity baseEntity, int weight, Dictionary<string, Result> resultsLookUp)
        {
            if (weight > 0)
            {
                if (!resultsLookUp.ContainsKey(baseEntity.Id))
                {
                    resultsLookUp[baseEntity.Id] = new Result { Id = baseEntity.Id, Name = baseEntity.Name, Type = baseEntity.EntityType };
                }

                resultsLookUp[baseEntity.Id].Weight = Math.Max(resultsLookUp[baseEntity.Id].Weight, weight);
            }
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
