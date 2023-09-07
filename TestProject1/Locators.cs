using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class Locators
    {
        //Xpath, Css, id, classname, name, tagname, linktext
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //Implicit wait 5 secunds (global)
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("lingwang");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("lingwang123");
            driver.FindElement(By.Id("password")).SendKeys("hdskjfksf");

            //CSS selector & Xpath
            //CSS: tagname[attribute = 'value']

            
            //Find element with XPath On SelectorHub 
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //Find element with CSS on SelectorHub #idvalue .classname
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();

            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            // Xpath: //tagname[@attribute = 'value']
            //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            //Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            String errorMessaage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessaage);

            //linktext
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr=link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            Assert.That(hrefAttr, Is.EqualTo(expectedUrl));

            //validate url of the link text

        }

    }
}
