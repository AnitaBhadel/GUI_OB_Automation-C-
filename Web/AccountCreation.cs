using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;

namespace Web
{
    [TestClass]
    public class AccountCreation // create the variable 
    {
        private IWebDriver driver;
        private string baseURL;
       // private bool passed = false;


        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            baseURL = "http://obc-mal-stg2.ms.frymulti.com/";
        }


        [TestMethod]
        public void AccountCreate()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("emailAddress")).SendKeys("musa24@yahoo.com");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("reEnterEmailAddress")).SendKeys("musa24@yahoo.com");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("passwordNewMember")).SendKeys("Apple123");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("verifyPassword")).SendKeys("Apple123");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("zipCode")).SendKeys("31313");
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value='Create An Account']")).Click();
            Thread.Sleep(4000);
        }

       
         [TestCleanup]
        public void Post()
        {
           try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile("Q:\\Screenshots\\AccountCreation" + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
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
