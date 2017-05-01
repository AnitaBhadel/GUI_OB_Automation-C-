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
    public class CusService_Confidence
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

        baseURL = "http://obc-apl-stg.ms.fry.com/";
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
        public void CustService_Confidence()
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
            driver.FindElement(By.LinkText("Customer Service")).Click();
            driver.FindElement(By.XPath("//img[@alt='Orchard Brands']")).Click();
            driver.FindElement(By.LinkText("Customer Service")).Click();
            driver.FindElement(By.LinkText("Learn About Us")).Click();
            driver.FindElement(By.LinkText("Privacy & Security")).Click();
            driver.FindElement(By.LinkText("Terms of Use")).Click();
            driver.FindElement(By.LinkText("Satisfaction Guaranteed")).Click();
            driver.FindElement(By.XPath("//img[@alt='Home']")).Click();
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
