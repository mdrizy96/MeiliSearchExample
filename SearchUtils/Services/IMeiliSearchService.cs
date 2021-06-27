using Meilisearch;
using SearchUtils.Models;
using SearchUtils.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchUtils.Services
{
    public interface IMeiliSearchService
    {
        Task<Index> CreateIndex(IndexForCreationDto indexForCreation);

        Task<IEnumerable<Index>> ListAllIndexes();

        Task<Index> GetIndex(string name);

        Task<bool> DeleteIndex(string name);

        Task<UpdateStatus> AddDocuments(string indexName);

        Task<UpdateStatus> AddOrUpdateDocuments(string indexName);

        Task<IEnumerable<Book>> GetDocumentsInIndex(string indexName);

        Task<Book> GetDocumentById(string indexName, string documentId);

        Task<UpdateStatus> DeleteOneDocument(string indexName, string documentId);

        Task<UpdateStatus> DeleteDocumentsInBatch(string indexName, List<string> documentIds);

        Task<UpdateStatus> DeleteAllDocumentsInIndex(string indexName);
    }
}