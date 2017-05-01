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
    public class CatalogRequest
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
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "https://10.231.1.126:8080";
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
        public void Catalog_Request()
        {
            
            // Login
            driver.Navigate().GoToUrl(baseURL + "/webclient/");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='BUTTON1']/div"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
                WebDriverWait wait = new WebDriverWait(driver, seconds);
                driver.Manage().Window.Maximize();
                Actions action = new Actions(this.driver);
                driver.FindElement(By.Id("FLD06053")).Clear();
                driver.FindElement(By.Id("FLD06053")).SendKeys("U92431");
                driver.FindElement(By.Id("PASSWORD1")).Clear();
            //Actual Password
                driver.FindElement(By.Id("PASSWORD1")).SendKeys("Winter17#");
                driver.FindElement(By.Id("PASSWORD1")).SendKeys(Keys.Enter);
                //Thread.Sleep(5000);
                //driver.FindElement(By.Id("FLD20007")).SendKeys("Xdirect cq" + Keys.Enter);
                Thread.Sleep(8000);
                // Catalog Request Fast Path
                driver.FindElement(By.Id("BUTTON8")).Click();
                Thread.Sleep(8000);
                driver.FindElement(By.Id("#1OOCD")).Clear();
                //Search By Postal Code
                driver.FindElement(By.Id("#1OOCD")).SendKeys("30427");
                driver.FindElement(By.Id("#1OOCD")).SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("BACK1")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("#1OOCD")).Clear();
                driver.FindElement(By.Id("#1OOCD")).SendKeys("");
                driver.FindElement(By.Id("#1L0TX")).Clear();
                // Last name and First name
                driver.FindElement(By.Id("#1L0TX")).SendKeys("DURRENCE");
                driver.FindElement(By.Id("#1LZTX")).SendKeys("JANJAN" + Keys.Enter);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("BACK1")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("BACK")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("BUTTON8")).Click();
                Thread.Sleep(8000);
                //New Catalog Request
                driver.FindElement(By.Id("#1JYNB")).SendKeys("955946578" + Keys.Enter);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("#1CACD")).SendKeys("SE3" + Keys.Enter);
            Thread.Sleep(3000);
            //    passed = true means that the test passed..... used to take screenshot
            passed = true;

        }

        //public void TakeScreenshot(ResultState result)
        //{

        //    DateTime time = DateTime.Now;
          

        //    if (NUnit.Framework.Test == ResultState.Failure)
        //    {
        //        //Thread.Sleep(15000);
        //        driver.TakeScreenshot().SaveAsFile(@"C:\\Users\\Admin\\Documents\\Automation_Results\\FailureScrnSht\\FailureScreenshot.png", System.Drawing.Imaging.ImageFormat.Png);
        //        //Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        //screenshot.SaveAsFile(@"C:\\Users\\Admin\\Documents\\Automation_Results\\FailureScrnSht\\FailureScreenshot.png, System.Drawing.Imaging.ImageFormat.Png);
        //    }
        //    else if (result == ResultState.Success)
        //    {
        //        //Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        //screenshot.SaveAsFile(@"C:\\Users\\Admin\\Documents\\Automation_Results\\SuccessScrnSht\\SuccessScreenshot.png, System.Drawing.Imaging.ImageFormat.Png);
        //    }
        //    else
        //    {

        //    }
        //}
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
