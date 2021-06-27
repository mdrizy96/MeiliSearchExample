using System.Collections.Generic;
using Meilisearch;
using System.Threading.Tasks;

namespace SearchUtils.Services
{
    public interface IMeiliSearchService
    {
        Task<Index> CreateIndex(string name);

        Task<Index> CreateIndexWithPrimaryKey(string name, string primaryKey);

        Task<IEnumerable<Index>> ListAllIndexes();

        Task<Index> GetIndex(string name);
    }
}