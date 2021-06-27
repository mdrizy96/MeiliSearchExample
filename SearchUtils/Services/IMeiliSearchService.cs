using System.Collections.Generic;
using Meilisearch;
using System.Threading.Tasks;
using SearchUtils.Models.Dtos;

namespace SearchUtils.Services
{
    public interface IMeiliSearchService
    {
        Task<Index> CreateIndex(IndexForCreationDto indexForCreation);

        Task<IEnumerable<Index>> ListAllIndexes();

        Task<Index> GetIndex(string name);
    }
}