using EaFramework.Config;
using Microsoft.Extensions.DependencyInjection;
using HomePage = EaApplicationTest.Pages.HomePage;
using IHomePage = EaApplicationTest.Pages.IHomePage;
using IProductPage = EaApplicationTest.Pages.IProductPage;
using ProductPage = EaApplicationTest.Pages.ProductPage;


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
                .AddScoped<IHomePage, HomePage>()
                .AddScoped<IProductPage, ProductPage>();
        }
    }
}
