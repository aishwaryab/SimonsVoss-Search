using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss_Search.BusinessLayer;
using SimonsVoss_Search.Models;

namespace SimonsVoss_Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet()]
        public IEnumerable<Result> Get(string searchTerm)
        {
            return _searchService.Search(searchTerm);
        }
    }
}
