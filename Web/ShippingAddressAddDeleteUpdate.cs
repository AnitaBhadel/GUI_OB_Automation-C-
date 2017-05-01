using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace Web
{
    [TestClass]
    public class ShippingAddressAddDeleteUpdate
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
        public void ShippingAddressAddDeleteupdate()
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
            driver.FindElement(By.LinkText("Address Book")).Click();
            Thread.Sleep(5000);

            IWebElement FirstName = driver.FindElement(By.Id("firstName"));
            FirstName.SendKeys("Anita");
            driver.FindElement(By.Id("lastName")).SendKeys("bhqadel");
            driver.FindElement(By.Id("address1")).SendKeys("740 south main st, 2F ");
            driver.FindElement(By.Id("city")).SendKeys("Hinesville");


            IWebElement mySelectState = driver.FindElement(By.Id("state"));
            SelectElement dropdown = new SelectElement(mySelectState);
            dropdown.SelectByIndex(12);


            driver.FindElement(By.Id("zipCode")).SendKeys("31313");
            driver.FindElement(By.Id("phone")).SendKeys("6464706680");
            driver.FindElement(By.XPath("//input[@value='Save Address to My Address Book']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("QAS_RefineText")).SendKeys("2F");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("QAS_RefineBtn")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#use-add-wrap > div.use-add-item-list > div:nth-child(2) > div > a.obutton.pie")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("address1")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("address1")).SendKeys("740 south main St, #3F");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@value='Save Address to My Address Book']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("QAS_RefineText")).SendKeys("2G");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("QAS_RefineBtn")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#use-add-wrap > div.use-add-item-list > div > div > a.linkButton.osecButton.pie.openAjaxLayer")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@value='Yes, Delete Address']")).Click();
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




    




