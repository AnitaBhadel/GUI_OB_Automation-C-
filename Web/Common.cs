using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web
{
    public class Common
    {
        private string baseURL;
        private ChromeDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);
            baseURL = "http://obc-mal-stg2.ms.frymulti.com/";
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
