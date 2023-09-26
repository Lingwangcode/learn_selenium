using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Reflection.Emit;

namespace TestProject1
{
    internal class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void SortTable()
        {
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropDown.SelectByValue("20");

            //Get all vegatable names into arraylist
            IList<IWebElement> vegetableElements = driver.FindElements(By.XPath("//tr//td[1]"));
            ArrayList vegetableNames = new ArrayList();
            foreach (IWebElement vegetable in vegetableElements)
            {
                vegetableNames.Add(vegetable.Text);
            }
            //print out the vegetabel names in array
            foreach (String vegetableName in vegetableNames)
            {
                TestContext.Progress.WriteLine(vegetableName);
            }
            //sort vagetale array
            vegetableNames.Sort();
            TestContext.Progress.WriteLine("after sorting");
            foreach (String vegetableName in vegetableNames) 
            {
                TestContext.Progress.WriteLine(vegetableName);
            }

            //click on element
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
            
            //get all sorted vegetable names into an array again
            ArrayList sortedVegetaleNames = new ArrayList();

            IList<IWebElement> sortedVegetableElements = driver.FindElements(By.XPath("//tr//td[1]"));
            
            foreach (IWebElement vegetable in sortedVegetableElements)
            {
                sortedVegetaleNames.Add(vegetable.Text);
            }
            //compare arrays
            Assert.AreEqual(vegetableNames, sortedVegetaleNames);


        }
    }
}
