using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumTests
{
    [TestClass]
    public class WinterSilksOrder
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private TimeSpan seconds;
        private bool passed = false;


        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            //driver = new ChromeDriver(@"C:\Users\Admin\Documents\Visual Studio 2015\chromedriver_win32");
            seconds = TimeSpan.FromSeconds(30);


            baseURL = "http://obc-mal-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
        }


        [TestCleanup]
        public void Post()
        {
            string time = DateTime.Now.ToString("MM-dd-yyyy_HHmm");

            try
            {
                if (passed)
                {
                    Thread.Sleep(5000);
                    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\Admin\\Documents\\Visual Studio 2015\\Projects\\GUI_Automation\\Screenshots\\SuccessScrnSht\\SuccessScreenshot_" + time + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    Thread.Sleep(5000);
                    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\Admin\\Documents\\Visual Studio 2015\\Projects\\GUI_Automation\\Screenshots\\FailureScrnSht\\FailureScreenshot_" + time + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                //driver.Quit();
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void WinterSilks()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            for (int second = 0; ; second++)
            {
                if (second >= 120) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("#brand-header > div.common-header-logo-container.fl > a > img"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(3000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]
            WebDriverWait wait = new WebDriverWait(driver, seconds);
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);
            driver.FindElement(By.CssSelector("#css_wts > a > img")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("SLEEPWEAR")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Sleepwear For Men")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Charmeuse Solid Pajama Set")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("sizeM")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Pine Green']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input.obutton.pie")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("heather.hughes@bluestem.com");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).SendKeys("Asher2016");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("jsAjaxSignIn")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(4000);
            MultiTab(5);  // My own creation
            Thread.Sleep(6000);
            //IDK what this is
            //driver.FindElement(By.Id("QAS_AcceptOriginal")).Click();
            //Thread.Sleep(3000);

            //Payment*******
            //driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.Id("creditCardRadio")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.Id("ccSecurityCode")).Clear();
            //Thread.Sleep(3000);

            //Security Code
            driver.FindElement(By.Id("ccSecurityCode")).SendKeys("321");
            Thread.Sleep(3000);
            //Place Order
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Place Order']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Orchard Brands']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Sign Out")).Click();
            //    passed = true means that the test passed..... used to take screenshot and separate passed and failed
            passed = true;
        }

        public void MultiTab(int numTab)
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
        
