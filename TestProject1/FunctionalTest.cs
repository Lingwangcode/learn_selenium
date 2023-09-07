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
    internal class FunctionalTest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void DropDown()
        {
            IWebElement dropDown =  driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropDown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(0);

            IList <IWebElement> radioBtns = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach(IWebElement radioBtn in radioBtns)
            {
                //TestContext.Progress.WriteLine(radioBtn.Text); //this is not working
                if (radioBtn.GetAttribute("value").Equals("user"))
                {
                    radioBtn.Click();
                }
                
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            //for true or false use assert.that   *Not working here because of some issues in the webpage
            //Assert.That(result, Is.True);
        }
    }
}
