using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void EndToEnd()
        {
            String[] expectedPro = { "iphone X", "Blackberry" };
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //PartialLinkText does not expect that the text is exactly the same as expected.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> productELements = driver.FindElements(By.TagName("app-card"));
            foreach(IWebElement pro in productELements)
            {
                String proText = pro.FindElement(By.CssSelector(".card-title a")).Text;
                foreach(String expectedProText in expectedPro)
                {
                    if (expectedProText.Equals(proText))
                    {
                        pro.FindElement(By.TagName("button")).Click();
                    }
                }
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

        }
    }
}
