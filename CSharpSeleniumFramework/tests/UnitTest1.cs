using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumFramework.tests
{
    internal class EToETest : Base
    {


        [Test]
        public void EndToEnd()
        {
            string[] expectedPro = { "iphone X", "Blackberry" };

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PartialLinkText does not expect that the text is exactly the same as expected.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> productELements = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement pro in productELements)
            {
                string proText = pro.FindElement(By.CssSelector(".card-title a")).Text;
                foreach (string expectedProText in expectedPro)
                {
                    if (expectedProText.Equals(proText))
                    {
                        pro.FindElement(By.TagName("button")).Click();
                    }
                }
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            //check if the items are expected in the cart
            IList<IWebElement> productElementListCheckOut = driver.FindElements(By.CssSelector("h4 a"));

            string[] actualProducts = new string[2];
            for (int i = 0; i < productElementListCheckOut.Count; i++)
            {

                actualProducts[i] = productElementListCheckOut[i].Text;
            }
            Assert.That(actualProducts, Is.EqualTo(expectedPro));

            //Click the Checkout button
            driver.FindElement(By.ClassName("btn-success")).Click();
            //Type "Ind"
            driver.FindElement(By.Id("country")).SendKeys("Ind");
            //Wait until "India" is visible (10sec)
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='India']")));
            driver.FindElement(By.XPath("//a[normalize-space()='India']")).Click();

            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            string successText = driver.FindElement(By.ClassName("alert-success")).Text.Trim();
            StringAssert.Contains("Success", successText);


        }
    }
}
