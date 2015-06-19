using DGDABackend.DataLayer;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace DgdaBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IProductsRepository, ProductsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
