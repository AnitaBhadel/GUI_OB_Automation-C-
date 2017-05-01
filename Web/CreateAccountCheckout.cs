using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Web
{
    [TestClass]
    public class CreateAccountCheckout
    {
        private IWebDriver driver;
        private string baseURL;
       // private bool passed=false;






        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            baseURL = "http://obc-mal-stg2.ms.frymulti.com/";
        }



        [TestMethod]
        public void CheckoutAccountCreate()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#css_apl > a > img")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("keyword")).SendKeys("shoes" + Keys.Enter);
            Thread.Sleep(4000);
            driver.FindElement(By.Id("4074")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("size37")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//img[@alt='Navy']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("input.obutton.pie")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            Thread.Sleep(4000);


            driver.FindElement(By.Id("firstName")).SendKeys("june");
            driver.FindElement(By.Id("lastName")).SendKeys("Bhadel");
            driver.FindElement(By.Id("address1")).SendKeys("211 S Tillman");
            driver.FindElement(By.Id("city")).SendKeys("Glennville");
            driver.FindElement(By.Id("state")).SendKeys("GA");
            driver.FindElement(By.Id("zipCode")).SendKeys("30427");
            driver.FindElement(By.Id("phone")).SendKeys("9124927837");
            driver.FindElement(By.Id("emailAddress")).SendKeys("Kancha123488@gmail.com");
            driver.FindElement(By.Id("reEnterEmailAddress")).SendKeys("Kancha123488@gmail.com");
            Thread.Sleep(3000);


            driver.FindElement(By.Id("actualPassword")).SendKeys("apple123");
            driver.FindElement(By.Id("verifyPassword")).SendKeys("apple123");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
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
