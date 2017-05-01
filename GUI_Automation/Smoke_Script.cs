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
    public class Smoke
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

            baseURL = "https://10.231.2.49:8080";
            verificationErrors = new StringBuilder();
            seconds = TimeSpan.FromSeconds(30);
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
        public void SmokeTest()
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
            // Source Code
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("MCADFAULT");
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT2")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Promotion
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.F9).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#1OCDP")).SendKeys("ASHP1" + Keys.Enter);
            Thread.Sleep(5000);
            // Add Gift Wrap
            driver.FindElement(By.Id("IMAGE5")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@id='#1NDST']/div[2]")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Order Msg
            driver.FindElement(By.Id("BUTTON9")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("P1")).Clear();
            driver.FindElement(By.Id("P1")).SendKeys("G");
            driver.FindElement(By.Id("TEXTAREA1")).Clear();
            driver.FindElement(By.Id("TEXTAREA1")).SendKeys("Geeft");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Protection Plus
            driver.FindElement(By.Id("RADIO2")).Click();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234" + Keys.Enter);
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(10000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Customer Selection
            driver.FindElement(By.Id("#CMKTV")).SendKeys("955946578" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
            // Source Code
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("WWTDFAULT");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("2061");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            //// Monogram
            //driver.FindElement(By.Id("I1")).Clear();
            //driver.FindElement(By.Id("I1")).SendKeys("Dis Bling" + Keys.Enter);
            //Thread.Sleep(5000);
            //driver.FindElement(By.Id("BACK")).Click();
            //Thread.Sleep(5000);
            // NTO Item
            driver.FindElement(By.Id("#CUCNO")).Clear();
            driver.FindElement(By.Id("#CUCNO")).SendKeys("ENT");
            driver.FindElement(By.Id("#2BECD")).SendKeys("22492");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Drapers
            driver.FindElement(By.Id("#CUCNO")).Clear();
            driver.FindElement(By.Id("#CUCNO")).SendKeys("WWD");
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("M02603");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(7000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            //Credit Card Disclaimer
            //action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            //Thread.Sleep(3000);
            //action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            //Thread.Sleep(3000);
            //action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            //Thread.Sleep(3000);
            //action.SendKeys(Keys.Enter).Perform();
            //Thread.Sleep(5000);
            // Protection Plus
            //driver.FindElement(By.Id("RADIO2")).Click();
            //action.SendKeys(Keys.Enter).Perform();
            //Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234" + Keys.Enter);
            Thread.Sleep(7000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(7000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Customer Selection
            driver.FindElement(By.Id("#CMKTV")).SendKeys("955946578" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
            // Source Code
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("WWWDFAULT");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // DropShip Itm
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("A0D330");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Set Item
            driver.FindElement(By.Id("#2BECD")).SendKeys("CIV15" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT8")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Hemming
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("22492");
            driver.FindElement(By.Id("#CUCNO")).Clear();
            driver.FindElement(By.Id("#CUCNO")).SendKeys("");
            driver.FindElement(By.Id("#CUCNO")).SendKeys("NTO" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("I1")).SendKeys("25" + Keys.Enter);
            Thread.Sleep(5000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(7000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(7000);
            // Protection Plus
            //driver.FindElement(By.Id("RADIO2")).Click();
            //action.SendKeys(Keys.Enter).Perform();
            //Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234" + Keys.Enter);
            Thread.Sleep(7000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(12000);
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
