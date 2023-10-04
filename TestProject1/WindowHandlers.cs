using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class WindowHandlers
    {
        IWebDriver driver;
        [SetUp] 
        public void Setup() 
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void WindowHandle()
        {
            String parentWindowId = driver.CurrentWindowHandle;

            driver.FindElement(By.ClassName("blinkingText")).Click();

            //There will be 2 windows oppen
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));

            //Switch driver to the window index 1, which is the child window.
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            TestContext.Progress.WriteLine(driver.FindElement(By.ClassName("red")).Text);
            String textContainsEmail = driver.FindElement(By.ClassName("red")).Text;
            String[] textContainsEmailInArray = textContainsEmail.Split(" ");
            String email = "";
            foreach(String e in textContainsEmailInArray)
            {
                if (e.Contains("@"))
                {
                    email = e;
                    break;
                }
            }
            //Switch to parent window
            //driver.SwitchTo().Window(driver.WindowHandles[0])
            driver.SwitchTo().Window(parentWindowId);
            driver.FindElement(By.Id("username")).SendKeys(email);

        }
    }
}
