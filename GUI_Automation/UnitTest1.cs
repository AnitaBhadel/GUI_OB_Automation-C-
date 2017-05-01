using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace GUI_Automation
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseURL;

        [TestInitialize]
        public void SetupTest()
        {
            

            baseURL = "https://gui-cp-qa.orchardbrands.biz:8080";
           
        }


        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(baseURL + "/webclient/");
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

           // driver.FindElement(By.Id("BACK1")).Click();
            //Thread.Sleep(5000);

            //action.SendKeys(Keys.Enter).Perform();
            
           // driver.FindElement(By.Id("FLD20007")).SendKeys("Xdirect cq" + Keys.Enter);
            //Thread.Sleep(8000);
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

            //navigate to payment 
            driver.FindElement(By.XPath("//*[@id='TABVIEW1']/div[1]/div/div/div[4]")).Click();
            Thread.Sleep(7000);

            // acccept offer
           driver.FindElement(By.Id("BACK")).Click();
            Thread.Sleep(5000);






            // add second item
            driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("00780");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT3")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);




            // driver.FindElement(By.Id("BACK")).Click();
            // Thread.Sleep(5000);
            //RADIO2


            //Adding second item to get 15% discount
            /*driver.FindElement(By.Id("#2BECD")).Clear();
            driver.FindElement(By.Id("#2BECD")).SendKeys("V009");
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='BACK']/div")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("TEXT1")).SendKeys("1" + Keys.Enter);
            Thread.Sleep(5000);*/

            driver.FindElement(By.XPath("//*[@id='TABVIEW1']/div[1]/div/div/div[4]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("RADIO2")).Click();

           Thread.Sleep(5000);
            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);

            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);





            driver.FindElement(By.XPath("//div[@id='#2K2NB']/input")).SendKeys("04");
            Thread.Sleep(5000);


            driver.FindElement(By.Id("BUTTON12")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Id("#1P6CD")).SendKeys("4444333322221111");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("#1D6DT")).SendKeys("0118");
            Thread.Sleep(6000);
           // driver.FindElement(By.XPath("//*[@id='BUTTON4']")).Click();
            //Thread.Sleep(5000);

            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("BUTTON20")).Click();
            Thread.Sleep(5000);


            action.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);




        }
    }
}
