using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //Here is something to remember!!!
            PageFactory.InitElements(driver, this);
        }
        //PageObject factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")] 
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = ".text-info span:nth-child(1) input")]
        private IWebElement agreeBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInButton;

        public void validLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            agreeBox.Click();
            signInButton.Click();
        }

        //public IWebElement GetUserName()
        //{
        //    return username;
        //}
        //public IWebElement GetPassword()
        //{
        //    return password;
        //}
        //public IWebElement GetAgreeBox()
        //{
        //    return agreeBox;
        //}
        //public IWebElement GetSignInButton()
        //{
        //    return signInButton;
        //}

    }
    

}
