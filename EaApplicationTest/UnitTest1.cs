using AutoFixture.Xunit2;
using EaFramework.Models;
using EaFramework.Pages;
using Xunit;


namespace EaApplicationTest
{
    public class UnitTest1
    {
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public UnitTest1(IHomePage homePage, IProductPage productPage)
        {
            _homePage = homePage;
            _productPage = productPage;
        }


        [Theory]
        [AutoData]
        public void ClickProduct(Product product)
        {
            // Click Create link
            _homePage.ClickProduct();

            // Create Product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);

        }

        [Theory]
        [AutoData]

        public void CreateAndSendProduct(Product product)
        {
            // Click Create link
            _homePage.ClickProduct();

            // Create Product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);

            _productPage.PerformCLickOnSpecialValue(product.Name, "Details");
        }



    }
}