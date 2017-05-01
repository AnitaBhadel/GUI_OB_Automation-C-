using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web
{
    [TestClass]
    public class AccountPasswordchange
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
        public void AccountpasswordChange()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
        }
    }
}
