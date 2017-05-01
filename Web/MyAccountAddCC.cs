using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
namespace SeleniumTests
{
    [TestClass]
    public class MyAccountAddCC
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        //private bool acceptNextAlert = true;
        //private TimeSpan seconds;


        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
           // seconds = TimeSpan.FromSeconds(30);

            baseURL = "http://obc-apl-stg2.ms.frymulti.com/";
            verificationErrors = new StringBuilder();
        }

       

        [TestMethod]
        public void MyaccountAddCC()
        {
            // Login
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
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


            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("anitaacharya123@yahoo.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("apple123");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            

            Thread.Sleep(3000);


            //Billing info
            driver.FindElement(By.LinkText("Billing Address & Credit Card Info")).Click();
             Thread.Sleep(3000);
            driver.FindElement(By.Id("ccName")).SendKeys("Danny Thomas");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ccNumber")).SendKeys("4444333322221111");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("creditCardExpiration")).Click();
            Thread.Sleep(3000);
            DropdownSelect(11);
            Thread.Sleep(3000);
            driver.FindElements(By.Name("ccYear")).ElementAt(1).Click();
            DropdownSelectYear(2);
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//input[@value='Save Credit Card']")).Click();
            //driver.FindElement(By.XPath("//*[@id='use-per-add-cc-wrap']/div/input")).Click();
            driver.FindElements(By.CssSelector("input.obutton.pie")).ElementAt(2).Click();
            Thread.Sleep(10000);




           





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



        public void DropdownSelect(int numMonth)
        {
            Actions action = new Actions(this.driver);
            while (numMonth > 0)
            {
                action.SendKeys(OpenQA.Selenium.Keys.ArrowDown).Build().Perform();
                Thread.Sleep(1000);
                numMonth--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }

        public void DropdownSelectYear(int numYear)
        {
            Actions action = new Actions(this.driver);
            while (numYear > 0)
            {
                action.SendKeys(OpenQA.Selenium.Keys.ArrowDown).Build().Perform();
                Thread.Sleep(1000);
                numYear--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }

      


        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }





    }
}