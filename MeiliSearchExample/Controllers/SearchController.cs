using Microsoft.AspNetCore.Mvc;
using SearchUtils.Services;
using System.Threading.Tasks;
using SearchUtils.Constants;

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

        [HttpPost("indexes")]
        public async Task<IActionResult> CreateIndex()
        {
            var res = await _searchService.CreateIndex(SearchConstants.BooksIndex);
            return Ok(res);
        }
    }
}