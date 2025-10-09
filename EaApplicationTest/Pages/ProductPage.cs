using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaFramework.Driver;
using EaFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EaApplicationTest.Pages
{
    public class ProductPage
    {
        private readonly IDriverFixture _driverFixture;
        public ProductPage(IDriverFixture driverFixture)
        {
            _driverFixture = driverFixture;
        }

        private IWebElement lnkCreate => _driverFixture.Driver.FindElement(By.LinkText("Create"));
        private IWebElement txtName => _driverFixture.Driver.FindElement(By.Id("Name"));
        private IWebElement txtDesc => _driverFixture.Driver.FindElement(By.Id("Description"));
        private IWebElement txtPrice => _driverFixture.Driver.FindElement(By.Id("Price"));
        private IWebElement ddlProductType => _driverFixture.Driver.FindElement(By.Id("ProductType"));
        private IWebElement btnCreate => _driverFixture.Driver.FindElement(By.Id("Create"));
        private IWebElement tblList => _driverFixture.Driver.FindElement(By.CssSelector(".table"));

        public void ClickCreateButton()
        {
            lnkCreate.Click();
        }

        public void CreateProduct(string productName, string productDescription, int price, string productType)
        {
            txtName.SendKeys(productName);
            txtDesc.SendKeys(productDescription);
            txtPrice.SendKeys(price.ToString());
            ddlProductType.SelectDropDownByText(productType);
            btnCreate.Click();
        }

        public void PerformCLickOnSpecialValue(string name, string operation)
        {
            tblList.PerformActionOnCell("5", "Name", name, operation);
        }


    }
}
