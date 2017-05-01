using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Web
{
    [TestClass]
    public class AccountPasswordUpdat
    {
        private IWebDriver driver;
        private string baseURL;


        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            baseURL = "http://obc-mal-stg2.ms.frymulti.com/";
        }



        [TestMethod]
        public void Accountpasswordupdate()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("anitaacharya123@yahoo.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("apple123");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Change My Email Address Or Password")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("currentPassword")).SendKeys("apple123");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("newPassword")).SendKeys("apple1234");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("verifyPassword")).SendKeys("apple1234");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@value='Update My Password']")).Click();
            Thread.Sleep(5000);
        }

        [TestCleanup]
        public void Post()
        {
            string time = DateTime.Now.ToString("MM-dd-yyyy_HHmm");

            try
            {


                Thread.Sleep(5000);
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile("Q:\\Screenshots\\CheckoutAcoountCreate" + time + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }


            catch (Exception)
            {

            }
            finally
            {
                driver.Quit();
            }
        }

    }
}
