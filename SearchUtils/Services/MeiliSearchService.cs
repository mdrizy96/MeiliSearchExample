using Meilisearch;
using Microsoft.Extensions.Options;
using SearchUtils.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchUtils.Models.Dtos;

namespace SearchUtils.Services
{
    public class MeiliSearchService : IMeiliSearchService
    {
        private readonly MeiliSearchClientOptions _searchClientOptions;

        public MeiliSearchService(IOptions<MeiliSearchClientOptions> searchClientOptions)
        {
            _searchClientOptions = searchClientOptions.Value;
        }

        public async Task<Index> CreateIndex(IndexForCreationDto indexForCreation)
        {
            var client = new MeilisearchClient(_searchClientOptions.InstanceUrl, _searchClientOptions.MasterKey);

            var index = indexForCreation.PrimaryKey switch
            {
                null => await client.CreateIndex(indexForCreation.Uid),
                _ => await client.CreateIndex(indexForCreation.Uid, indexForCreation.PrimaryKey)
            };

            return index;
        }

        public async Task<IEnumerable<Index>> ListAllIndexes()
        {
            var client = new MeilisearchClient(_searchClientOptions.InstanceUrl, _searchClientOptions.MasterKey);
            var allIndexes = await client.GetAllIndexes();

            return allIndexes;
        }

        public async Task<Index> GetIndex(string name)
        {
            var client = new MeilisearchClient(_searchClientOptions.InstanceUrl, _searchClientOptions.MasterKey);
            var index = await client.GetIndex(name);

            return index;
        }
    }
}