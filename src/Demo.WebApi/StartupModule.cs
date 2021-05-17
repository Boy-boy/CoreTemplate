using Core.Modularity;
using Core.Modularity.Attribute;
using Demo.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using Core.EventBus;
using Core.EventBus.RabbitMQ;
using Core.EventBus.SqlServer;
using Core.Uow;

namespace Demo.WebApi
{

    [DependsOn(
        typeof(ApplicationModule),
        typeof(CoreEventBusRabbitMqModule)
       /* typeof(CoreEventBusSqlServerModule)*/)]
    public class StartupModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddControllers();
            context.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Demo.WebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //若基于本地消息表存储event，需配置      
            context.Services.Configure<EventBusSqlServerOptions>(options =>
            {
                options.DbConnectionStr = Configuration.GetConnectionString("Demo");
            });

            #region 若是订阅服务，需要添加以下代码
            //将MessageHandler注入到容器里
            //context.Services.TryRegistrarMessageHandlers(new[] { typeof(StartupModule).Assembly });
            //context.Services.Configure<EventBusOptions>(options =>
            //{
            //    //实现自动订阅messageHandler
            //    options.AutoRegistrarHandlersAssemblies = new[] { typeof(StartupModule).Assembly };
            //});
            #endregion
        }
        public override void Configure(ApplicationBuilderContext context)
        {
            var app = context.ApplicationBuilder;
            var env = context.ApplicationBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo v1");
                });

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}
