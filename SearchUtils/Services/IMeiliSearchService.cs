using Meilisearch;
using System.Threading.Tasks;

namespace SearchUtils.Services
{
    public interface IMeiliSearchService
    {
        Task<Index> CreateIndex(string name);
    }
}