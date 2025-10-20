using EaFramework.Config;
using EaFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace EaApplicationTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(ConfigReader.ReadConfig())
                .AddScoped<IDriverFixture, DriverFixture>()
                .AddScoped<IDriverWait, DriverWait>()
                .AddScoped<Pages.IHomePage, Pages.HomePage>()
                .AddScoped<Pages.IProductPage, Pages.ProductPage>();
        }
    }
}
