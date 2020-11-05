using Core.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Mvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationManager<StartupModule>();
        }
       
        public void Configure(IApplicationBuilder app)
        {
            app.InitializationApplicationBuilder();
        }
    }
}
