using Microsoft.AspNetCore.Mvc;
using SearchUtils.Constants;
using SearchUtils.Models.Dtos;
using SearchUtils.Services;
using System.Collections.Generic;
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
        public async Task<IActionResult> CreateIndex([FromBody] IndexForCreationDto indexForCreation)
        {
            if (string.IsNullOrEmpty(indexForCreation.Uid))
            {
                indexForCreation.Uid = SearchConstants.BooksIndex;
            }
            var res = await _searchService.CreateIndex(indexForCreation);
            return Ok(res);
        }

        [HttpDelete("indexes/{indexName}")]
        public async Task<IActionResult> DeleteSingleIndex(string indexName)
        {
            var res = await _searchService.DeleteIndex(indexName);
            return Ok(res);
        }

        [HttpPost("indexes/{indexName}/documents")]
        public async Task<IActionResult> AddOrReplaceDocuments(string indexName)
        {
            var res = await _searchService.AddDocuments(indexName);
            return Ok(res);
        }

        [HttpPut("indexes/{indexName}/documents")]
        public async Task<IActionResult> AddOrUpdateDocuments(string indexName)
        {
            var res = await _searchService.AddOrUpdateDocuments(indexName);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/documents")]
        public async Task<IActionResult> GetDocumentsInIndex(string indexName)
        {
            var res = await _searchService.GetDocumentsInIndex(indexName);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/documents/{documentId}")]
        public async Task<IActionResult> GetDocumentById(string indexName, string documentId)
        {
            var res = await _searchService.GetDocumentById(indexName, documentId);
            return Ok(res);
        }

        [HttpDelete("indexes/{indexName}/documents/{documentId}")]
        public async Task<IActionResult> DeleteOneDocument(string indexName, string documentId)
        {
            var res = await _searchService.DeleteOneDocument(indexName, documentId);
            return Ok(res);
        }

        [HttpDelete("indexes/{indexName}/documents/delete-batch")]
        public async Task<IActionResult> DeleteOneDocument(string indexName, [FromBody] List<string> documentIds)
        {
            var res = await _searchService.DeleteDocumentsInBatch(indexName, documentIds);
            return Ok(res);
        }

        [HttpDelete("indexes/{indexName}/documents")]
        public async Task<IActionResult> DeleteAllDocumentsInIndex(string indexName)
        {
            var res = await _searchService.DeleteAllDocumentsInIndex(indexName);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/updates")]
        public async Task<IActionResult> GetAllUpdateStatus(string indexName)
        {
            var res = await _searchService.GetAllUpdateStatus(indexName);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/updates/{updateStatusId}")]
        public async Task<IActionResult> GetStatusForOneUpdate(string indexName, int updateStatusId)
        {
            var res = await _searchService.GetUpdateStatusById(indexName, updateStatusId);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/search")]
        public async Task<IActionResult> BasicSearch(string indexName, [FromQuery] string searchQuery)
        {
            var res = await _searchService.BasicSearch(indexName, searchQuery);
            return Ok(res);
        }

        [HttpGet("indexes/{indexName}/search/custom")]
        public async Task<IActionResult> CustomSearch(string indexName, [FromQuery] string searchQuery)
        {
            var res = await _searchService.CustomSearch(indexName, searchQuery);
            return Ok(res);
        }
    }
}