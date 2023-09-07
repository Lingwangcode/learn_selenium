using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class SeleniumFirst
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new ChromeDriver();

            //driver = new FirefoxDriver();

            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();

        }
        [Test] public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            //driver.Close();//close only 1 window
            //driver.Quit(); //close all the windows what cost buy automation
        }
    }
}
