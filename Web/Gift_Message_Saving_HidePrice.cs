using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTests
{
    [TestClass]
    public class Gift_Message_Saving_HidePrice
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private TimeSpan seconds;
        //private ChromeOptions options;
        

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            //driver = new ChromeDriver(@"C:\Users\admin2\Documents\Visual Studio 2015\chromedriver_win32");
            //options.AddArgument("no-sandbox");
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-apl-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
        }

      

        [TestMethod]
        public void GiftMessage_Saving_HidePrice()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("#brand-header > div.common-header-logo-container.fl > a > img"))) break;


                }
                catch (Exception)
                { }
                Thread.Sleep(3000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]




          
            driver.FindElement(By.LinkText("APPAREL")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("bottoms")).Click();
            Thread.Sleep(10000);
            driver.FindElements(By.ClassName("image-container")).ElementAt(1).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.Id("73933")).Click();
            Thread.Sleep(6000);

            

            driver.FindElement(By.Id("size10")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='White']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Add To Shopping Bag']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("heather.hughes@bluestem.com");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Asher2016");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("jsAjaxSignIn")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(6000);

          
            driver.FindElement(By.CssSelector("span.jsAddGifting")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='productList']/div/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("giftMessage1")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("giftMessage1")).SendKeys("You are the best");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("excludePricesInPackingSlip")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("creditCardRadio")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ccSecurityCode")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ccSecurityCode")).SendKeys("416");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Place Order']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("img[alt=\"Appleseeds\"]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Sign Out")).Click();
        }

        


        /*public void MultiTab(int numTab)
        {
            Actions action = new Actions(this.driver);
            while (numTab > 0)
            {
                action.SendKeys(OpenQA.Selenium.Keys.Tab).Build().Perform();
                numTab--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }

        public void MultiShiftTab(int numTab)
        {
            Actions action = new Actions(this.driver);
            while (numTab > 0)
            {
                action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
                numTab--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }*/

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        

    }

}
