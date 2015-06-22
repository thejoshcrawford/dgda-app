using DGDABackend.DataLayer;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace DgdaBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddSingleton<IProductsRepository, ProductsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "http://localhost:3000" });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "accept, content-type, origin" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                return next();
            });
         //   app.UseCors(builder =>
           //     builder.WithOrigins("http://localhost:3000"));
            app.UseMvc();
        }
    }
}
