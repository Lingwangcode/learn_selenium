using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
    internal class ProductsPage
    {
        //pro.FindElement(By.CssSelector(".card-title a")).Text;
        private By cardTitle;
        private By addButton;
        IWebDriver driver;
        public ProductsPage(IWebDriver driver) 
        {
            this.driver = driver;
            this.cardTitle = By.CssSelector(".card-title a");
            this.addButton = By.TagName("button");
            PageFactory.InitElements(driver, this);
        }
        

        //IList<IWebElement> productELements = GetDriver().FindElements(By.TagName("app-card"));
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        //GetDriver().FindElement(By.PartialLinkText("Checkout")).Click();
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;

        public void waitForProductPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PartialLinkText does not expect that the text is exactly the same as expected.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        }
        public IList<IWebElement> GetCards() 
        {
            return cards;
        }
        public By GetCardTitle() { return cardTitle; }
        public By GetAddButton() { return addButton; }
        public OrderComfirm Checkout() 
        { 
            checkoutButton.Click();
            return new OrderComfirm(driver);
        }
    }
}
