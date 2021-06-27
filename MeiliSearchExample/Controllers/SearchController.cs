using Microsoft.AspNetCore.Mvc;
using SearchUtils.Constants;
using SearchUtils.Services;
using System.Threading.Tasks;

namespace MeiliSearchExample.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMeiliSearchService _searchService;

        public SearchController(IMeiliSearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("indexes")]
        public async Task<IActionResult> GetAllIndexes()
        {
            var res = await _searchService.ListAllIndexes();
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}")]
        public async Task<IActionResult> GetSingleIndex(string indexName)
        {
            var res = await _searchService.GetIndex(indexName);
            return Ok(res);
        }

        [HttpPost("indexes")]
        public async Task<IActionResult> CreateIndex()
        {
            var res = await _searchService.CreateIndex(SearchConstants.BooksIndex);
            return Ok(res);
        }
    }
}