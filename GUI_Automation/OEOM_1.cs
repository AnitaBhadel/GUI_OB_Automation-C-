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
    public class OEOM
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
            //{
                //driver.Quit();
            //}
            Assert.AreEqual("", verificationErrors.ToString());
        }*/

        [TestMethod]
        public void OEOMTest()
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
            driver.FindElement(By.Id("FLD06053")).SendKeys("U92431");
            driver.FindElement(By.Id("PASSWORD1")).Clear();
            driver.FindElement(By.Id("PASSWORD1")).SendKeys("Winter17#");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("FLD20007")).SendKeys("Xdirect cq" + Keys.Enter);
            Thread.Sleep(8000);
            driver.FindElement(By.Id("BUTTON1")).Click();
            Thread.Sleep(10000);
            // Customer Selection
            driver.FindElement(By.Id("#CMKTV")).SendKeys("957390133" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
           
            // Delete Appeasements
            if (IsElementPresent(By.Id("BACK1")))
            {
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
                
            } 

            // Source Code
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("TEL2");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(7000);
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("V009");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='BACK']/div")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            //action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            //Thread.Sleep(3000);
            //action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            //Thread.Sleep(3000);
            //action.SendKeys(Keys.Enter).Perform();
            //Thread.Sleep(5000);
            // Order Msg
            driver.FindElement(By.Id("BUTTON9")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXTAREA1")).Clear();
            driver.FindElement(By.Id("TEXTAREA1")).SendKeys("Something good");

            driver.FindElement(By.Id("P1")).Clear();
            driver.FindElement(By.Id("P1")).SendKeys("P" + Keys.Enter);
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
           
            // Multi-Ship
            driver.FindElement(By.Id("BUTTON2")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#PLZTX")).Clear();
            driver.FindElement(By.Id("#PLZTX")).SendKeys("Smiley");
            driver.FindElement(By.Id("#PL0TX")).Clear();
            driver.FindElement(By.Id("#PL0TX")).SendKeys("Jim");
            driver.FindElement(By.Id("#PL1TX1")).Clear();
            driver.FindElement(By.Id("#PL1TX1")).SendKeys("458 All Along the Watchtower");
            driver.FindElement(By.Id("#POOCD")).SendKeys("99519");
            driver.FindElement(By.Id("#PL5TX")).Clear();
            driver.FindElement(By.Id("#PL5TX")).SendKeys("Anchorage");
            // Nontaxable State
            driver.FindElement(By.Id("#PH6ST")).Clear();
            driver.FindElement(By.Id("#PH6ST")).SendKeys("AK");
            driver.FindElement(By.Id("#PHZCG")).Clear();
            driver.FindElement(By.Id("#PHZCG")).SendKeys("9121446351");
            driver.FindElement(By.Id("#PH0CG")).Clear();
            driver.FindElement(By.Id("#PH0CG")).SendKeys("9125446892");
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("MCADFAULT");
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Second Item
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT3")).SendKeys("1" + Keys.Enter);
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
            // Protection Plus
            driver.FindElement(By.Id("RADIO2")).Click();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("BUTTON12")).Click();
            //action.SendKeys(Keys.Tab).Perform();
            driver.FindElement(By.Id("#2P6CD")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#2D6DT")).Click();
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(8000);
            //driver.FindElement(By.Id("RADIO2")).Click();
            //Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Source Code
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("MCADFAULT");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Adding Item 1
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 2
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 3
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("TEXT2")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 4
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT4")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 5
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT5")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 6
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT7")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 7
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT3")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 8
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT8")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 9
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("TEXT6")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 10
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("TEXT5")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 11
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("TEXT7")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Adding Item 12
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            // Protection Plus
            driver.FindElement(By.Id("RADIO2")).Click();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            action.SendKeys(Keys.Tab).Perform();
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234");
            driver.FindElement(By.Id("#2D6DT")).Click();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(8000);
            if (IsElementPresent(By.Id("RADIO2")))
            {
                driver.FindElement(By.Id("RADIO2")).Click();
                Thread.Sleep(3000);
            }
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Source Code
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("MX6DFAULT");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            // Adding Items
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("GCAS");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT3")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            // Gift Card To/From
            driver.FindElement(By.Id("I1")).Clear();
            driver.FindElement(By.Id("I1")).SendKeys("A FRAND");
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);
            // Customer Choice
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            action.SendKeys(Keys.F12).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON11")).Click();
            Thread.Sleep(5000);
            // Payment
            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            action.SendKeys(Keys.Tab).Perform();
            driver.FindElement(By.Id("#2P6CD")).Clear();
            driver.FindElement(By.Id("#2P6CD")).SendKeys("4444333322221111");
            driver.FindElement(By.Id("#2D6DT")).SendKeys("1234");
            driver.FindElement(By.Id("#2D6DT")).Click();
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON20")).Click();
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
