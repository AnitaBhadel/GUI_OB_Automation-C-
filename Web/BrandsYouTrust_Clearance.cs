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
    public class BrandsYouTrust_Clearance
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private TimeSpan seconds;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\\Users\\Admin\\Documents\\CodeDeploy\\Driver");
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-mal-stg.ms.fry.com/";
            verificationErrors = new StringBuilder();
        }

        //[TestCleanup]
        //public void TeardownTest()
        //{
        //    try
        //    {
        //        driver.Quit();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //    }
        //    Assert.AreEqual("", verificationErrors.ToString());
        //}

        [TestMethod]
        public void BYT_Clearance()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='BUTTON1']/div"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]
            driver.FindElement(By.XPath("//img[contains(@src,'http://orchard.blair.com/assets/mal/General/Brands_01_Appleseeds_on.gif')]")).Click();
            driver.FindElement(By.LinkText("Roll-Sleeve Boat-Neck Tee by Appleseed's")).Click();
            driver.FindElement(By.Id("sizeM")).Click();
            driver.FindElement(By.XPath("//img[@alt='Fresh Coral']")).Click();
            driver.FindElement(By.XPath("//input[@value='Add To Shopping Bag']")).Click();
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            driver.FindElement(By.Id("userName")).Clear();
            driver.FindElement(By.Id("userName")).SendKeys("edutton@orchardbrands.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Scoobydoo55!");
            driver.FindElement(By.Id("jsAjaxSignIn")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.Id("QAS_AcceptOriginal")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.Id("creditCardRadio")).Click();
            driver.FindElement(By.Id("ccSecurityCode")).Clear();
            driver.FindElement(By.Id("ccSecurityCode")).SendKeys("123");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.XPath("//input[@value='Place Order']")).Click();
            driver.FindElement(By.CssSelector("img[alt=\"Orchard Brands\"]")).Click();
            driver.FindElement(By.CssSelector("img[alt=\"Home\"]")).Click();
            driver.FindElement(By.LinkText("SHOP CLEARANCE")).Click();
            driver.FindElement(By.LinkText("Fleece-Lined Anorak Jacket")).Click();
            driver.FindElement(By.Id("sizeMED")).Click();
            driver.FindElement(By.XPath("//img[@alt='Claret']")).Click();
            driver.FindElement(By.XPath("//input[@value='Add To Shopping Bag']")).Click();
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.Id("QAS_AcceptOriginal")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.Id("creditCardRadio")).Click();
            driver.FindElement(By.Id("ccSecurityCode")).Clear();
            driver.FindElement(By.Id("ccSecurityCode")).SendKeys("123");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.XPath("//input[@value='Place Order']")).Click();
            driver.FindElement(By.XPath("//img[@alt='Orchard Brands']")).Click();
            driver.FindElement(By.CssSelector("img[alt=\"Home\"]")).Click();
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
