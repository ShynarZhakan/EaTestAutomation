using EaFramework.Models;
using EaFramework.Driver;
using EaFramework.Extensions;
using OpenQA.Selenium;

namespace EaFramework.Pages
{
    public interface IProductPage
    {
        void ClickCreateButton();
        void CreateProduct(Product product);
        void PerformCLickOnSpecialValue(string name, string operation);

        string GetProductName();
    }

    public class ProductPage : IProductPage
    {
        private readonly IDriverWait _driver;

        public ProductPage(IDriverWait driver)
        {
            _driver = driver;
        }

        private IWebElement lnkCreate => _driver.FindElement(By.LinkText("Create"));
        private IWebElement txtName => _driver.FindElement(By.Id("Name"));
        private IWebElement txtDesc => _driver.FindElement(By.Id("Description"));
        private IWebElement txtPrice => _driver.FindElement(By.Id("Price"));
        private IWebElement ddlProductType => _driver.FindElement(By.Id("ProductType"));
        private IWebElement btnCreate => _driver.FindElement(By.Id("Create"));
        private IWebElement tblList => _driver.FindElement(By.CssSelector(".table"));

        public void ClickCreateButton()
        {
            lnkCreate.Click();
        }

        public void CreateProduct(Product product)
        {
            txtName.SendKeys(product.Name);
            txtDesc.SendKeys(product.Description);
            txtPrice.SendKeys(product.Price.ToString());
            ddlProductType.SelectDropDownByText(product.ProductType.ToString());
            btnCreate.Click();
        }

        public void PerformCLickOnSpecialValue(string name, string operation)
        {
            tblList.PerformActionOnCell("5", "Name", name, operation);
        }

        public string GetProductName() => txtName.Text;


    }
}
