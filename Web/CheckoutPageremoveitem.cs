using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Web
{
    [TestClass]
    public class CheckoutPageremoveitem
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
        public void CheckoutPageremoveItem()
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
            DropdownItemNumber();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("input.obutton.pie")).Click();
            Thread.Sleep(4000);


            driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            Thread.Sleep(4000);

        }

        public void DropdownItemNumber(){
            IWebElement ItemNumber = driver.FindElement(By.ClassName("add_to_bag_qty fl open"));
            SelectElement dropdown = new SelectElement(ItemNumber);
            dropdown.SelectByIndex(5);
    }


        /*  [TestCleanup]
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
          }*/


    }

}
