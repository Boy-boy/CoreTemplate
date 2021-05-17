using Core.Modularity;
using Core.Modularity.Attribute;
using Demo.Adapter;
using Demo.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application
{
    [DependsOn(
        typeof(PersistentModule),
        typeof(AdapterModule))]
    public class ApplicationModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public ApplicationModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddScoped<StudentServices>();
        }
    }
}
