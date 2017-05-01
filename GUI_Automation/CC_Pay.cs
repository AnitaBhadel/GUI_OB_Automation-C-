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
    public class CCPay
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
        public void TheCCPayTest()
        {
            // Order Entry
            driver.FindElement(By.Id("BUTTON1")).Click();
            // Cus Select
            driver.FindElement(By.Id("#CMKTV")).Clear();
            driver.FindElement(By.Id("#CMKTV")).SendKeys("402568880");
            driver.FindElement(By.Id("BUTTON4")).Click();
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("wwwdfault");
            driver.FindElement(By.Id("BUTTON4")).Click();
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            driver.FindElement(By.Id("BUTTON3")).Click();
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON1")).Click();
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.F12);
            driver.FindElement(By.Id("BUTTON1")).Click();
            // Payment Information
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("BUTTON12")).Click();  // ERROR: Caught exception [ERROR: Unsupported command [clickAt | id=BUTTON12 | ${KEY_F14}]]
            driver.FindElement(By.Id("#1P6CD")).Clear();
            driver.FindElement(By.Id("#1P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#1D6DT")).Clear();
            driver.FindElement(By.Id("#1D6DT")).SendKeys("1217");
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("BUTTON20")).Click();
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
