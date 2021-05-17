using Core.EntityFrameworkCore;
using Core.Modularity;
using Core.Modularity.Attribute;
using Demo.Domain.Repositories;
using Demo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Persistence
{
    [DependsOn(typeof(CoreEfCoreModule))]
    public class PersistentModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public PersistentModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void PreConfigureServices(ServiceCollectionContext context)
        {
            context.Items.Add(nameof(CustomerDbContext), typeof(CustomerDbContext));
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
            });
            context.Services.AddScoped<IStudentsRepository, StudentsRepository>();
        }
    }
}
