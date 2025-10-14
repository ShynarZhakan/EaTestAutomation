using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;
        public UnitTest1()
        {
            var testSettings = new TestSettings
            {
                BrowserType = DriverFixture.BrowserType.Chrome,
                ApplicationUrl = new Uri("http://localhost:8000/"),
                TimeoutInternal = 30
            };

            _driverFixture = new DriverFixture(testSettings);

        }


        [Fact]
        public void Test1()
        {
            // HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);

            // Click Create link
            homePage.ClickProduct();

            // Create Product
            productPage.ClickCreateButton();
            productPage.CreateProduct("POM product", "POM Description", 4000, "CPU");

        }

        [Theory]
        [InlineData("FirstProduct", "New prod description", 21354, "CPU")]
        [InlineData("FirstProduct2", "New prod description", 3000, "MONITOR")]
        public void Test2(string name, string description, int price, string productType)
        {
            // HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);

            // Click Create link
            homePage.ClickProduct();

            // Create Product
            productPage.ClickCreateButton();
            productPage.CreateProduct(name, description, price, productType);

            productPage.PerformCLickOnSpecialValue(name, "Details");
        }



        public void Dispose()
        {
            _driverFixture.Driver?.Quit();  // ? here is checking if driver is null or not. 
        }
    }
}