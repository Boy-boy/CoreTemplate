using Core.ElasticSearch;
using Core.Modularity;
using Core.Modularity.Attribute;
using Demo.Adapter.ElasticSearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Adapter
{
    [DependsOn(typeof(CoreElasticSearchModule))]
    public class AdapterModule:CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public AdapterModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddSingleton(typeof(IGlobalElasticSearchRepository<>),typeof(GlobalElasticSearchRepository<>));
        }
    }
}
