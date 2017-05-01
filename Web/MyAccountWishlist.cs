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
    public class MyAccountWishlist
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private TimeSpan seconds;

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-apl-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
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


        [TestMethod]
        public void MyaccountWishlist()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Id("home"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(3000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]
            Actions action = new Actions(this.driver);

            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("heather.hughes@bluestem.com");            
            driver.FindElement(By.Id("password")).Clear();            
            driver.FindElement(By.Id("password")).SendKeys("Asher2016");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            Thread.Sleep(3000);
            //Wishlist
            driver.FindElement(By.XPath("//*[@id='use-mai-wrap']/div[3]/div[2]/h3/a")).Click();
            Thread.Sleep(3000);
           

         
         
          



            //Order status

            //driver.FindElement(By.XPath("//*[@id='use - per - add - cc - wrap']/fieldset/div[3]/span/select[2]")).SendKeys("2020");
            //Thread.Sleep(3000);




            //Email and Password Section
            //driver.FindElement(By.XPath("//*[@id='use-mai-wrap']/div[3]/div[2]/h3/a")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("#inc-lef-user-nav-wrap > ul > li:nth-child(4) > a")).Click();

            //Sign out 
            //driver.FindElement(By.LinkText("Sign Out")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//img[@alt='Home']")).Click();

            driver.FindElement(By.XPath("//*[@id='keyword']")).SendKeys("V009");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#brand-header > div.links-search-container > div.search-keyword-container.oldSearch.formFieldContainer.dontVerify.overLabeled > form > span > input.srchBtn")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='4427']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='sizeL']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#swatches-4427 > div:nth-child(2) > img")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#product-details > div.main-item.fill-height > div.item-container > form > div.image-description-container > div.description-container > div.pdp-ui-wrap > div.shop-action > div:nth-child(2) > div.add-item-container.fr > div.add-to-wish-list > a")).Click();
            Thread.Sleep(3000);





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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
