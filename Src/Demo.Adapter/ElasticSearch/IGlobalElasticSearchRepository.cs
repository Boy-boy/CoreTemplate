using Core.ElasticSearch;

namespace Demo.Adapter.ElasticSearch
{
    public interface IGlobalElasticSearchRepository<T> : IElasticSearchRepositories<T>
    where T : class
    {
    }
}
