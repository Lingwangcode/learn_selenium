using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
   
    internal class OrderComfirm
    {
        IWebDriver driver;
        
        public OrderComfirm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //GetDriver().FindElements(By.CssSelector("h4 a"))
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> cards;

        //GetDriver().FindElement(By.ClassName("btn-success")).Click();
        [FindsBy(How = How.ClassName, Using = "btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> GetCards()
        {
            return cards;
        }
        public CheckoutPage checkout()
        {
            checkoutButton.Click();
            return new CheckoutPage(driver);
        }

        
    }
}
