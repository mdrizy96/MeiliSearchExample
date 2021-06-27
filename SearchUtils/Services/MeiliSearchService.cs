using Meilisearch;
using Microsoft.Extensions.Options;
using SearchUtils.Models;
using System.Threading.Tasks;

namespace SearchUtils.Services
{
    public class MeiliSearchService : IMeiliSearchService
    {
        private readonly MeiliSearchClientOptions _searchClientOptions;

        public MeiliSearchService(IOptions<MeiliSearchClientOptions> searchClientOptions)
        {
            _searchClientOptions = searchClientOptions.Value;
        }

        public async Task<Index> CreateIndex(string name)
        {
            var client = new MeilisearchClient(_searchClientOptions.InstanceUrl, _searchClientOptions.MasterKey);
            // An index is where the documents are stored.
            var index = await client.CreateIndex(name);

            return index;
        }
    }
}