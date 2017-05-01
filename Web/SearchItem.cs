using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class Search
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private TimeSpan seconds;

        [TestInitialize]
        public void SetupTest()
        {
           string path = Environment.GetEnvironmentVariable("chromedriver");
           driver = new ChromeDriver(path);
            //driver = new ChromeDriver(@"C:\Users\admin2\Documents\Visual Studio 2015\chromedriver_win32");
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-apl-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
        }

       

        [TestMethod]
        public void ItemSearch()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            for (int second = 0; second >= 60; second++)
            {
                try
                {
                    if (IsElementPresent(By.Id("keyword"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(3000);
            }

            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]

            driver.FindElement(By.Id("keyword")).SendKeys("Long Sleeve Silk Blend Rib Mockneck" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("sizeS")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Black']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Add To Shopping Bag']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("heather.hughes@bluestem.com");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Asher2016");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("jsAjaxSignIn")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ccSecurityCode")).SendKeys("321");
            Thread.Sleep(3000);

            //Place Order
            //driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            //Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Place Order']")).Click();
            Thread.Sleep(5000);
           
        }


      

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



        [TestCleanup]
        public void TeardownTest()
        {
          try
           {
               driver.Quit();
           }
            catch (Exception)
            {
               // Ignore errors if unable to close the browser
           }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
    }

}
