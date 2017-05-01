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
    public class ShoppingBagUpdate
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private TimeSpan seconds;

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-apl-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
        }

        //[TestCleanup]
        //public void TeardownTest()
        //{
        //    try/
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
        public void ShoppingBagUpdateWishL()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Id("home"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(3000);
            }

            //driver.FindElement(By.CssSelector("#css_apl > a > img")).Click();
            //Thread.Sleep(3000);
            driver.FindElement(By.LinkText("PETITES")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("keyword")).SendKeys("shoes" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("4074")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("size37")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Black']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input.obutton.pie")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.LinkText("Close")).Click();
            //Thread.Sleep(12000);

            Actions action = new Actions(this.driver);
            IWebElement miniCart = driver.FindElement(By.Id("widget-but-ucart"));
            action.MoveToElement(miniCart).Build().Perform();
            Thread.Sleep(8000);

            driver.FindElement(By.CssSelector("#widget-but-ucart > a")).Click();
            Thread.Sleep(10000);



                 driver.FindElement(By.CssSelector("#shopping-cart-items > tbody > tr:nth-child(8) > td > a:nth-child(1)")).Click();
                Thread.Sleep(10000);
                MultiShiftTab(35);
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//img[@alt='Navy']")).Click();
                Thread.Sleep(10000);
                            //MultiTab(2);
                           // Thread.Sleep(10000);
                driver.FindElement(By.CssSelector("input.obutton:nth-child(3)")).Click();
                Thread.Sleep(10000);
            
                //Wishlist
                driver.FindElement(By.CssSelector("#shopping-cart-items > tbody > tr:nth-child(8) > td > a:nth-child(3)")).Click();
                Thread.Sleep(4000);
                driver.FindElement(By.Id("userName")).SendKeys("heather.hughes@bluestem.com");
                driver.FindElement(By.Id("password")).Clear();
                driver.FindElement(By.Id("password")).SendKeys("Asher2016" + Keys.Enter);
                Thread.Sleep(3000);
                ////driver.FindElement(By.Id("widget-but-ucart")).Click();
                //Thread.Sleep(3000);
                ////driver.FindElement(By.LinkText("Tops")).Click();
                ////Thread.Sleep(3000);
                ////driver.FindElement(By.LinkText("Mocks & Turtlenecks")).Click();
                ////Thread.Sleep(3000);
                //driver.FindElement(By.LinkText("Close")).Click();
                //Thread.Sleep(3000);
                //driver.FindElement(By.Id("widget-but-ucart")).Click();
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
