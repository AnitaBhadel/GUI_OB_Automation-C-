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
    using System;
    using System.IO;
    using System.Linq;

    [TestClass]
    public class PLCCpayment
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
        public void PLCC()
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

            //THIS is the blank test. This is where your code will go... Heather..

            driver.FindElement(By.XPath("//*[@id='keyword']")).SendKeys("V009" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='sizeS']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='swatches-4427']/div[1]/img")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#product-details > div.main-item.fill-height > div.item-container > form > div.image-description-container > div.description-container > div.pdp-ui-wrap > div.shop-action > div:nth-child(2) > div.add-item-container.fr > div.obuttonWrap > input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#header-checkout > input[type='image']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='firstName']")).SendKeys("Bob" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='lastName']")).SendKeys("Dylan" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='address1']")).SendKeys("3681 Raymond D Bland Rd" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='city']")).SendKeys("Glennville" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='state']")).SendKeys("Ga" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='zipCode']")).SendKeys("30427" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='phone']")).SendKeys("9126541212" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='emailAddress']")).SendKeys("don12@gmail.com" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='reEnterEmailAddress']")).SendKeys("don12@gmail.com" + Keys.Enter);
            Thread.Sleep(3000);










            //    passed = true means that the test passed..... used to take screenshot
            passed = true;
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
                else
                {
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
