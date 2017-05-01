using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;

namespace Web
{
    [TestClass]
    public class WriteReview
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
        public void Writereview()
        {
            driver.Navigate().GoToUrl(baseURL + "/home.jsp");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("keyword")).SendKeys("shoes" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("113215")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Write a review")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("userName")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("userName")).SendKeys("anitaacharya123@yahoo.com");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("password")).SendKeys("apple1234");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("star_link_rating_2")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("star_link_rating_Quality_2")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("star_link_rating_Value_2")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BVFieldRecommendNoID")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BVFieldTitleID")).SendKeys("Good");
            Thread.Sleep(6000);
            driver.FindElement(By.Id("BVFieldReviewtextID")).SendKeys("happy with the product.hhhhhhhhhhhh hhhhhhhh ggggggggg");
            Thread.Sleep(6000);
            driver.FindElements(By.ClassName("BVButton")).ElementAt(0).Click();
            Thread.Sleep(6000);
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

