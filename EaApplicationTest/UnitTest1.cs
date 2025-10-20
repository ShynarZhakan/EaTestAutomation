using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using EaFramework.Driver;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private readonly IDriverFixture _driverFixture;
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public UnitTest1(IDriverFixture driverFixture,  IHomePage homePage, IProductPage productPage)
        {
            _driverFixture = driverFixture;
            _homePage = homePage;
            _productPage = productPage;
        }


        [Theory]
        [AutoData]
        public void Test1(Product product)
        {
            // Click Create link
            _homePage.ClickProduct();

            // Create Product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);

        }

        [Theory]
        [AutoData]

        public void Test2(Product product)
        {
            // Click Create link
            _homePage.ClickProduct();

            // Create Product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);

            _productPage.PerformCLickOnSpecialValue(product.Name, "Details");
        }



        public void Dispose()
        {
            _driverFixture.Driver?.Quit();  // ? here is checking if driver is null or not. 
        }
    }
}