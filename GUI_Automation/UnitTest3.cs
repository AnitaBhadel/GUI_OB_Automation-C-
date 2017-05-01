using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace GUI_Automation

{
    [TestClass]
    public class UnitTest3

    {
        private string baseURL;
        IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);

            baseURL = "https://gui-cp-qa.orchardbrands.biz:8080/webclient/";

        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(5000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            Actions action = new Actions(this.driver);
            driver.FindElement(By.Id("FLD06053")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("FLD06053")).SendKeys("U92538CQ");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("PASSWORD1")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("PASSWORD1")).SendKeys("Apple1@3");
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("BUTTON1")).Click();
            Thread.Sleep(10000);
            // Customer Selection
            driver.FindElement(By.Id("#CMKTV")).SendKeys("957390133" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON4")).Click();
            Thread.Sleep(5000);
            // Source Code
            driver.FindElement(By.Id("#PHGCE")).Clear();
            driver.FindElement(By.Id("#PHGCE")).SendKeys("TEL2");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            //add item
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("V009");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='BACK']/div")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("#2GUCD")).SendKeys("956");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#2GVCD")).SendKeys("L");
            Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);

            // Order Msg
            driver.FindElement(By.Id("BUTTON9")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXTAREA1")).Clear();
            driver.FindElement(By.Id("TEXTAREA1")).SendKeys("Something good");
        }
    }
}
