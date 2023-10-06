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
    internal class CheckoutPage
    {
        IWebDriver driver;
        private By indiaCountry;
        public CheckoutPage(IWebDriver driver) 
        {
            this.driver = driver;
            indiaCountry = By.XPath("//a[normalize-space()='India']");
            PageFactory.InitElements(driver, this);
            
        }
        //GetDriver().FindElement(By.Id("country")).SendKeys("Ind");
        //GetDriver().FindElement(By.XPath("//a[normalize-space()='India']")).Click();
        //GetDriver().FindElement(By.CssSelector("label[for='checkbox2']")).Click();
        //GetDriver().FindElement(By.CssSelector("input[value='Purchase']")).Click();
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='India']")]
        private IWebElement india;

        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2']")]
        private IWebElement agreeBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement purchaseButton;
        //GetDriver().FindElement(By.ClassName("alert-success")).Text.Trim();
        [FindsBy(How = How.ClassName, Using = "alert-success")]
        private IWebElement seccessLabel;
        public void purchase()
        {
            country.SendKeys("Ind");
            waitForContriesToBeVisible();
            india.Click();
            agreeBox.Click();
            purchaseButton.Click();
        }

        public String GetSeccessLabel() { return seccessLabel.Text; }
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='India']")));
        public void waitForContriesToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(indiaCountry));
        }



    }
}
