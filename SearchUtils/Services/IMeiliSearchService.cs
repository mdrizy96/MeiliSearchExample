using Meilisearch;
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
    }
}