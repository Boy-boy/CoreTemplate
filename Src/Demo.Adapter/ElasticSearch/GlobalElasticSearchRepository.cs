using Core.ElasticSearch;
using Microsoft.Extensions.Options;

namespace Demo.Adapter.ElasticSearch
{
    public class GlobalElasticSearchRepository<T>: ElasticSearchRepositories<T>, IGlobalElasticSearchRepository<T>
       where T : class
    {
        public GlobalElasticSearchRepository(IElasticClientFactory elasticClientFactory)
        :base(elasticClientFactory,Options.DefaultName)
        {
        }
    }
}
