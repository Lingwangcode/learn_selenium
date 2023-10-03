using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    internal class MouseAction
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com";
        }
        [Test]
        public void test_Actions()
        {

            /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("dropdown-toggle")));
            */
            Thread.Sleep(3000);
            
            Actions a = new Actions(driver);
           
            a.MoveToElement(driver.FindElement(By.ClassName("dropdown-toggle"))).Perform();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();

        }
        [Test]
        public void test_DraggAndDropp()
        {

            driver.Url = "https://demoqa.com/droppable";

            Actions a = new Actions(driver);

            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();

        }
    }
}
