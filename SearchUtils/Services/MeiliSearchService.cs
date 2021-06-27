using Meilisearch;
using Microsoft.Extensions.Options;
using SearchUtils.Constants;
using SearchUtils.Models;
using SearchUtils.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchUtils.Services
{
    public class MeiliSearchService : IMeiliSearchService
    {
        private readonly MeilisearchClient _masterSearchClient;

        public MeiliSearchService(IOptions<MeiliSearchClientOptions> searchClientOptions)
        {
            var searchClientOptions1 = searchClientOptions.Value;
            _masterSearchClient = new MeilisearchClient(searchClientOptions1.InstanceUrl, searchClientOptions1.MasterKey);
        }

        public async Task<Index> CreateIndex(IndexForCreationDto indexForCreation)
        {
            var index = indexForCreation.PrimaryKey switch
            {
                null => await _masterSearchClient.CreateIndex(indexForCreation.Uid),
                _ => await _masterSearchClient.CreateIndex(indexForCreation.Uid, indexForCreation.PrimaryKey)
            };

            return index;
        }

        public async Task<IEnumerable<Index>> ListAllIndexes()
        {
            var allIndexes = await _masterSearchClient.GetAllIndexes();

            return allIndexes;
        }

        public async Task<Index> GetIndex(string name)
        {
            var index = await _masterSearchClient.GetIndex(name);

            return index;
        }

        public async Task<bool> DeleteIndex(string name)
        {
            var res = await _masterSearchClient.DeleteIndex(name);

            return res;
        }

        public async Task<UpdateStatus> AddDocuments(string indexName)
        {
            var index = await _masterSearchClient.GetIndex(SearchConstants.BooksIndex);
            var documents = new Book[] {
                new Book { BookId = "123",  Title = "Pride and Prejudice" },
                new Book { BookId = "456",  Title = "Le Petit Prince" },
                new Book { BookId = "1",    Title = "Alice In Wonderland" },
                new Book { BookId = "1344", Title = "The Hobbit" },
                new Book { BookId = "4",    Title = "Harry Potter and the Half-Blood Prince" },
                new Book { BookId = "42",   Title = "The Hitchhiker's Guide to the Galaxy" }
            };
            // If the index 'books' does not exist, MeiliSearch creates it when you first add the documents.
            var update = await index.AddDocuments<Book>(documents);

            return update;
        }

        public async Task<UpdateStatus> AddOrUpdateDocuments(string indexName)
        {
            var index = await _masterSearchClient.GetIndex(SearchConstants.BooksIndex);
            var documents = new Book[] { new Book { BookId = "1", Title = "Alice aux Pays des Merveilles" } };
            var update = await index.UpdateDocuments(documents);
            return update;
        }
    }
}