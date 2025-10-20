using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using EaFramework.Driver;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;
        private IDriverWait _driverWait;
        public UnitTest1()
        {
           var testSettings = ConfigReader.ReadConfig();

            _driverFixture = new DriverFixture(testSettings);
            _driverWait = new DriverWait(_driverFixture, testSettings);

        }


        [Theory]
        [AutoData]
        public void Test1(Product product)
        {
            // HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);

            // Click Create link
            homePage.ClickProduct();

            // Create Product
            productPage.ClickCreateButton();
            productPage.CreateProduct(product);

        }

        [Fact]
        
        public void Test2()
        {
            // HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);

            var product = new Product
            {
                Name = "New Prod",
                Description = "New Product",
                Price = 12312,
                ProductType = ProductType.EXTERNAL
            };

            // Click Create link
            homePage.ClickProduct();

            // Create Product
            productPage.ClickCreateButton();
            productPage.CreateProduct(product);

            productPage.PerformCLickOnSpecialValue(product.Name, "Details");
        }



        public void Dispose()
        {
            _driverFixture.Driver?.Quit();  // ? here is checking if driver is null or not. 
        }
    }
}