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
    public class OIOM
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

            baseURL = "https://gui-cp-qa.orchardbrands.biz:8080";
            verificationErrors = new StringBuilder();
        }

        /*[TestCleanup]
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
        }*/

        [TestMethod]
        public void OIOMTest()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/webclient/");
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='BUTTON1']/div"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);
            driver.FindElement(By.Id("FLD06053")).Clear();
            driver.FindElement(By.Id("FLD06053")).SendKeys("u92431");
            driver.FindElement(By.Id("PASSWORD1")).Clear();
            driver.FindElement(By.Id("PASSWORD1")).SendKeys("Winter17#");
            action.SendKeys(Keys.Enter).Perform();
            //thread.sleep(3000);
            //driver.findelement(by.id("fld20007")).sendkeys("xdirect cq" + keys.enter);
            Thread.Sleep(8000);
            driver.FindElement(By.Id("IMAGE4")).Click();
            Thread.Sleep(8000);
            // Lookup by Last And First Name
            driver.FindElement(By.Id("#PL0TX1")).SendKeys("DURRENCE");
            driver.FindElement(By.Id("#PL0TX1")).Click();
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("#2LZTX")).SendKeys("JAN");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(3000);
            // Lookup by Email
            driver.FindElement(By.Id("#DYETU1")).SendKeys("janjan@durrence.com");
            driver.FindElement(By.Id("#DYETU1")).Click();
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(3000);
            // Order Lookup
            driver.FindElement(By.Id("#1JWNB1")).SendKeys("37733654" + Keys.Enter); //469
            Thread.Sleep(3000);
            // Options Buttons Verification
            action.SendKeys(Keys.F10).Perform();
            Thread.Sleep(3000);
            // Ticklers Button
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Display Open to Buy Button
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Options Buttons Verification
            action.SendKeys(Keys.F10).Perform();
            Thread.Sleep(6000);
            // Customer Action Notes
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Options Buttons Verification
            action.SendKeys(Keys.F10).Perform();
            Thread.Sleep(6000);
            // Merch Credits
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Customer Profile Button
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK2")).Click();
            Thread.Sleep(6000);
            // VIP Billing
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Customer Notes
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Gift Card Balance
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
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Display Picks Button
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
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Pre-Approved Request Button
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Letter Request Button
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Instant Credit Button
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Available Rewards Button
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("Cancel")).Click();
            Thread.Sleep(6000);
            // VIP Plus Help
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Maintain Order
            action.SendKeys(Keys.F7).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(6000);
            // Add Item to Existing Order
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("V009");
            driver.FindElement(By.Id("#CUCNO")).Clear();
            driver.FindElement(By.Id("#CUCNO")).SendKeys("");
            driver.FindElement(By.Id("#CUCNO")).SendKeys("WWW" + Keys.Enter);
            Thread.Sleep(6000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(6000);
            driver.FindElement(By.Id("#1CONQ")).SendKeys("6");
            driver.FindElement(By.Id("#1CONQ")).Click();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(6000);
            // Change Ship Via
            driver.FindElement(By.Id("BACK1")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("(//input[@type='text'])[25]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[25]")).SendKeys("");
            driver.FindElement(By.XPath("(//input[@type='text'])[25]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[25]")).SendKeys("Priority");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Submit Changes
            action.SendKeys(Keys.F9).Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.F9).Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Exit to Lookup Screen
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(6000);
            // Customer Lookup by Phone
            driver.FindElement(By.Id("#PGJCG1")).SendKeys("(912)654-3210");
            driver.FindElement(By.Id("#PGJCG1")).Click();
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(6000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Order Lookup
            driver.FindElement(By.Id("#1JWNB1")).SendKeys("37733656" + Keys.Enter); //464
            Thread.Sleep(6000);
            // Order Detail
            driver.FindElement(By.Id("BUTTON4")).SendKeys(Keys.F6);
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            //driver.FindElement(By.Id("BUTTON42")).Click();
            //Thread.Sleep(6000);
            // Ticklers
            driver.FindElement(By.Id("BUTTON5")).Click();
            Thread.Sleep(6000);
            //Create Ticklers
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
            Thread.Sleep(6000);
            // Back
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Exit
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Exit Options
            action.SendKeys(Keys.Tab).Perform();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Appeasements
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("P1")).SendKeys("A6");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Exit Appeasements
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
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Maintain Order
            action.SendKeys(Keys.F7).Perform();
            Thread.Sleep(6000);
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
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            // Cancel Order
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.F8).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("#PFHSS")).SendKeys("y");
            driver.FindElement(By.Id("#PJ7NB")).SendKeys("98");
            driver.FindElement(By.Id("#PJ7NB")).Click();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(6000);
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
