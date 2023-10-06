using CSharpSeleniumFramework.pageObjects;
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

            LoginPage login = new LoginPage(GetDriver());

            //login.GetUserName().SendKeys("rahulshettyacademy");
            //login.GetPassword().SendKeys("learning");
            //login.GetAgreeBox().Click();
            //login.GetSignInButton().Click();

            //ProductsPage productsPage = new ProductsPage(GetDriver());
            ProductsPage productsPage = login.validLogin("rahulshettyacademy", "learning");

            productsPage.waitForProductPage();

            //IList<IWebElement> productELements = GetDriver().FindElements(By.TagName("app-card"));
            IList<IWebElement> products = productsPage.GetCards();
            foreach (IWebElement pro in products)
            {
                string proText = pro.FindElement(productsPage.GetCardTitle()).Text;
                foreach (string expectedProText in expectedPro)
                {
                    if (expectedProText.Equals(proText))
                    {
                        pro.FindElement(productsPage.GetAddButton()).Click();
                    }
                }
            }

            OrderComfirm orderComfirm = productsPage.Checkout();

            //check if the items are expected in the cart
            IList<IWebElement> cardsCheckout = orderComfirm.GetCards();
            string[] actualProducts = new string[2];

            for (int i = 0; i < cardsCheckout.Count; i++)
            {
                actualProducts[i] = cardsCheckout[i].Text;
            }
            Assert.That(actualProducts, Is.EqualTo(expectedPro));

            //Click the Checkout button, landing on the checkout page
            CheckoutPage checkoutPage = orderComfirm.checkout();

           
            checkoutPage.purchase();

            string successText = checkoutPage.GetSeccessLabel();
            StringAssert.Contains("Success", successText);


        }
    }
}
