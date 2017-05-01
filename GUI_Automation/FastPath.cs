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
    public class FastPaths
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private bool passed = false;

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);

            baseURL = "https://10.231.2.49:8080";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void Post()
        {
            string time = DateTime.Now.ToString("MM-dd-yyyy_HHmm");
            //add some stuff
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
        public void Fast_Path()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/webclient/");
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
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);
            driver.FindElement(By.Id("FLD06053")).Clear();
            driver.FindElement(By.Id("FLD06053")).SendKeys("U92434CQ");
            driver.FindElement(By.Id("PASSWORD1")).Clear();
            driver.FindElement(By.Id("PASSWORD1")).SendKeys("Thing123");
            driver.FindElement(By.Id("PASSWORD1")).SendKeys(Keys.Enter);
            //Thread.Sleep(5000);
            //driver.FindElement(By.Id("FLD20007")).SendKeys("Xdirect cq" + Keys.Enter);
            Thread.Sleep(8000);
            // Left Column
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(8000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON19")).Click();
            Thread.Sleep(8000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON18")).Click();
            Thread.Sleep(8000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON17")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON15")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("Menu")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON14")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON16")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON12")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON10")).Click();
            Thread.Sleep(15000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            // Center Column
            driver.FindElement(By.Id("BUTTON9")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON6")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON7")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            // RIght Column
            driver.FindElement(By.Id("BUTTON29")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON28")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON27")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON26")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON25")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON24")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON23")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON22")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
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
