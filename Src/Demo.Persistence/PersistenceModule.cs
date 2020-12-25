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

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddDbContextPool<DemoDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Demo"));
            });
            context.Services.AddScoped<IStudentsRepository, StudentsRepository>();
        }
    }
}
