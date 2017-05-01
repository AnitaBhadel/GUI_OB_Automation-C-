using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumTests
{
    [TestClass]
    public class ShoppingBagMiniCRemove
    {
        private IWebDriver driver;
        //private StringBuilder verificationErrors;
        private string baseURL;
        //private bool acceptNextAlert = true;
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
            //verificationErrors = new StringBuilder();
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
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void ShoppingBagminicRemove()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            //for (int second = 0; ; second++)
            //{
            //    if (second >= 120) Assert.Fail("timeout");
            //    try
            //    {
            //        if (IsElementPresent(By.CssSelector("#brand-header > div.common-header-logo-container.fl > a > img"))) break;
            //    }
            //    catch (Exception)
            //    { }
            //    Thread.Sleep(3000);
            //}
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 500 | ]]
            WebDriverWait wait = new WebDriverWait(driver, seconds);
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);
            driver.FindElement(By.CssSelector("#css_apl > a > img")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("PETITES")).Click();
            Thread.Sleep(3000);

            //driver.FindElement(By.XPath("//*[@id='Classic Petite Clothing for Women']/div[6]/div[2]/div[2]/div/map/area[17]")).Click();
            //Thread.Sleep(3000);
            ////Click twice because of popup.....looking for other solution
            //driver.FindElement(By.XPath("//*[@id='monetate_lightbox_content']/form/table/tbody/tr[1]/td/a/img")).Click();
            //Thread.Sleep(3000);

            driver.FindElement(By.Id("keyword")).SendKeys("shoes" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("4074")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("size37")).Click();
            Thread.Sleep(3000);

            

            // use the below format of XPath to get the same results every time :)
            driver.FindElement(By.XPath("//img[@alt='Black']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input.obutton.pie")).Click();
            Thread.Sleep(10000);

            //Mini cart hover test code
            IWebElement miniCart = driver.FindElement(By.Id("widget-but-ucart"));
            action.MoveToElement(miniCart).Build().Perform();
            driver.FindElement(By.LinkText("edit")).Click();
            Thread.Sleep(3000);
          //  driver.SwitchTo().Frame("LL_DataServer");
            //driver.SwitchTo().ActiveElement();
            //driver.FindElement(By.XPath("//img[@alt='Navy]")).Click();
           // Thread.Sleep(3000);











            driver.FindElement(By.CssSelector("#glo-ucart-slider-content > div > span:nth-child(5) > a:nth-child(1)")).Click();
             Thread.Sleep(3000);

            ////Checkout    
            //driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            //Thread.Sleep(3000);

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

    }
}

