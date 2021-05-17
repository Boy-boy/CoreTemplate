using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Core.Modularity;

namespace Demo.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServiceCollection<StartupModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.BuildApplicationBuilder();
        }
    }
}
