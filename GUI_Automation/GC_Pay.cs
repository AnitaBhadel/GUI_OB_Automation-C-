using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class GCPay
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://gui-cp-qa.orchardbrands.biz:8080/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
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
        
        [Test]
        public void TheGCPayTest()
        {
            // Order Entry
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON1 | ]]
            // Cus Select
            driver.FindElement(By.Id("#CMKTV")).Clear();
            driver.FindElement(By.Id("#CMKTV")).SendKeys("402568880");
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON4 | ]]
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("wwwdfault");
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON4 | ]]
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON3 | ]]
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            // Customer Choice
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON11 | ]]
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.F12);
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON11 | ]]
            // Payment Information
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("15");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON12 | ${KEY_F14}]]
            driver.FindElement(By.Id("#1P6CD")).Clear();
            driver.FindElement(By.Id("#1P6CD")).SendKeys("193415762338");
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.Enter);
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON20 | ]]
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.Enter);
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
