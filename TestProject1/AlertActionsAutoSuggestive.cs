using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class AlertActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void test_Alert()
        {
            String name = "Ling";
            driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[value=Confirm]")).Click();
            String text = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("Hello");
            StringAssert.Contains(name, text);
        }
        [Test]
        public void test_AutoSuggestiveDropDowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            IList<IWebElement> options = driver.FindElements(By.ClassName("ui-menu-item"));

        }
    }
}
