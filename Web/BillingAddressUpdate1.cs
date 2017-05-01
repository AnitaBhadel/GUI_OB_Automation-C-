using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Web
{
    [TestClass]
    public class BillingAddressUpdate1
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
        public void BillingAddressupdate()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.LinkText("Sign In")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("anitaacharya123@yahoo.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("apple1234");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Billing Address & Credit Card Info")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("firstName")).SendKeys("Anita");
            Thread.Sleep(5000);

            driver.FindElement(By.Id("lastName")).Clear();
            driver.FindElement(By.Id("lastName")).SendKeys("Acharya");
            Thread.Sleep(5000);


            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys("750 South main Street");
            Thread.Sleep(5000);

            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("Savannah");
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//input[@value='Update Billing Address']")).Click();
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
