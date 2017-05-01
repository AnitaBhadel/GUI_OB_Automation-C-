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
    public class CreditRequest
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

        baseURL = "https://10.231.2.49:8080";
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
        public void Credit_Request()
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
            WebDriverWait wait = new WebDriverWait(driver, seconds);
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);
            driver.FindElement(By.Id("FLD06053")).Clear();
            driver.FindElement(By.Id("FLD06053")).SendKeys("U92434CQ");
            driver.FindElement(By.Id("PASSWORD1")).Clear();
            driver.FindElement(By.Id("PASSWORD1")).SendKeys("Thing123");
            action.SendKeys(Keys.Enter).Perform();
            //wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("FLD20007"))));
            //driver.FindElement(By.Id("FLD20007")).SendKeys("Xdirect cq" + Keys.Enter);
            wait.Until((ExpectedConditions.TextToBePresentInElementLocated(By.Id("BUTTON1"), "Order Entry")));
            driver.FindElement(By.Id("BUTTON1")).Click();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("#CMKTV"))));
            // Customer Select
            driver.FindElement(By.Id("#CMKTV")).SendKeys("955946578" + Keys.Enter);
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("BUTTON4"))));
            driver.FindElement(By.Id("BUTTON4")).Click();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("#PHGCE"))));
            // Adding Items/Source Code
            driver.FindElement(By.Id("#PHGCE")).SendKeys("WWWDFAULT" + Keys.Enter);
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("#2BECD"))));
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("H205");
            driver.FindElement(By.Id("BUTTON3")).Click();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("TEXT6"))));
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(3000);
            // Credit Request
            driver.FindElement(By.Id("BUTTON19")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("#SSN1"))));
            driver.FindElement(By.Id("#SSN1")).Clear();
            driver.FindElement(By.Id("#SSN1")).SendKeys("827");
            driver.FindElement(By.Id("#SSN2")).Clear();
            driver.FindElement(By.Id("#SSN2")).SendKeys("34");
            driver.FindElement(By.Id("#SSN3")).Clear();
            driver.FindElement(By.Id("#SSN3")).SendKeys("9651");
            driver.FindElement(By.XPath("(//input[@type='text'])[14]")).SendKeys("04201995 " + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(3000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='#2K2NB']/input"))));
            //Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("05");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("5112010000000003");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234" + Keys.Enter);
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("BUTTON4"))));
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
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
