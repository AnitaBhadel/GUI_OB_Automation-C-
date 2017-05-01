using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OtherStuff
{
    [TestClass]
    public class OBPayroll
    {
        private IWebDriver driver;
        private string baseURL;
        private string contents;
        private DateTime date = DateTime.Now;  
        //FInds current user's documents folder for use later in test
        private string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        [TestInitialize]
        public void Setup()
        {
            string path = Environment.GetEnvironmentVariable("chromedriver");
            driver = new ChromeDriver(path);

            baseURL = "https://onshore.basecamphq.com/clients";
        }

        [TestMethod]
        public void OB()
        {

            // to get previous month for file dating and time reports
            date = date.AddMonths(-1);
            int m = date.Month;
            int y = date.Year;
            //Gets number of days in the month for use as the end date of the corresponding month, automatically
            string endDate = DateTime.DaysInMonth(y, m).ToString();
            string month = date.ToString("MMM");
            string year = date.ToString("yyyy");

            //**
            //Begin test
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            Actions action = new Actions(this.driver);

            //This is where actions start.. Page has opened and maximized..
            Thread.Sleep(750);
            //Test Start
            //Login
            driver.FindElement(By.Id("username")).SendKeys("heidi.ernst@onshoreoutsourcing.com");
            driver.FindElement(By.Id("password")).SendKeys("Sapp8447" + Keys.Enter);
            Thread.Sleep(4000);

            //Orchard Brands
            driver.FindElement(By.LinkText("Orchard Brands QA Extension")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Time")).Click();
            Thread.Sleep(1000);
            //Create 1st Report
            driver.FindElement(By.Id("report_link")).Click();
            Thread.Sleep(750);
            //Selecting user from dropdown 1
            driver.FindElement(By.Id("subject_id")).Click();
            driver.FindElement(By.Id("subject_id")).SendKeys("Heather Hughes" + Keys.Enter);
            Thread.Sleep(750);
            //starting date select 2
            driver.FindElement(By.Id("from_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).SendKeys(month + " " + year + Keys.Enter);
            Thread.Sleep(750);
            driver.FindElement(By.LinkText("1")).Click();
            Thread.Sleep(750);
            //ending date select 3
            driver.FindElement(By.Id("to_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.LinkText(endDate)).Click();
            Thread.Sleep(750);
            driver.FindElement(By.Id("to_date_display")).SendKeys(Keys.Enter);
            Thread.Sleep(750);
            //saving time slot to variable 4
            string heather = "Heather Hughes = " + driver.FindElement(By.Id("hours_subtotal")).Text + " \r\n";
            Thread.Sleep(3000);
            //Create 2nd Report
            driver.FindElement(By.Id("report_link")).Click();
            Thread.Sleep(750);
            //1
            driver.FindElement(By.Id("subject_id")).Click();
            driver.FindElement(By.Id("subject_id")).SendKeys("Ethan Dutton" + Keys.Enter);
            Thread.Sleep(750);
            //2
            driver.FindElement(By.Id("from_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).SendKeys(month + " " + year + Keys.Enter);
            Thread.Sleep(750);
            driver.FindElement(By.LinkText("1")).Click();
            Thread.Sleep(750);
            //3
            driver.FindElement(By.Id("to_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.LinkText(endDate)).Click();
            Thread.Sleep(750);
            driver.FindElement(By.Id("to_date_display")).SendKeys(Keys.Enter);
            Thread.Sleep(750);
            //4
            string ethan = "Ethan Dutton = " + driver.FindElement(By.Id("hours_subtotal")).Text + " \r\n";
            Thread.Sleep(3000);
            //Create 3rd Report
            driver.FindElement(By.Id("report_link")).Click();
            Thread.Sleep(750);
            //1
            driver.FindElement(By.Id("subject_id")).Click();
            driver.FindElement(By.Id("subject_id")).SendKeys("Tracy Smith" + Keys.Enter);
            Thread.Sleep(750);
            //2
            driver.FindElement(By.Id("from_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).SendKeys(month + " " + year + Keys.Enter);
            Thread.Sleep(750);
            driver.FindElement(By.LinkText("1")).Click();
            Thread.Sleep(750);
            //3
            driver.FindElement(By.Id("to_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.LinkText(endDate)).Click();
            Thread.Sleep(750);
            driver.FindElement(By.Id("to_date_display")).SendKeys(Keys.Enter);
            Thread.Sleep(750);
            //4
            string tracy = "Tracy Smith = " + driver.FindElement(By.Id("hours_subtotal")).Text + " \r\n";
            Thread.Sleep(3000);
            //Create 4th Report
            driver.FindElement(By.Id("report_link")).Click();
            Thread.Sleep(750);
            //1
            driver.FindElement(By.Id("subject_id")).Click();
            driver.FindElement(By.Id("subject_id")).SendKeys("Anita Acharya" + Keys.Enter);
            Thread.Sleep(750);
            //2
            driver.FindElement(By.Id("from_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.ClassName("months")).SendKeys(month + " " + year + Keys.Enter);
            Thread.Sleep(750);
            driver.FindElement(By.LinkText("1")).Click();
            Thread.Sleep(750);
            //3
            driver.FindElement(By.Id("to_date_display")).Click();
            Thread.Sleep(750);
            driver.FindElement(By.LinkText(endDate)).Click();
            Thread.Sleep(750);
            driver.FindElement(By.Id("to_date_display")).SendKeys(Keys.Enter);
            Thread.Sleep(750);
            //4
            string anita = "Anita Acharya = " + driver.FindElement(By.Id("hours_subtotal")).Text + " \r\n";
            Thread.Sleep(3000);

            //Combining Time Slots
            contents = heather + ethan + tracy + anita;
            //Creating client folder in current user's documents folder if it does not exist
            if (!Directory.Exists(docs + "\\OB"))
                {
                    Directory.CreateDirectory(docs + "\\OB");
                }
            //Creating and writing slots to text file in client folder title with the appropriate numerical month and year date
            System.IO.File.WriteAllText(docs + "\\OB\\" + date.ToString("MMyyyy") + ".txt", contents);

            //End of Test
            //**



            //IList<IWebElement> check = driver.FindElements(By.ClassName("check"));
            //check.ElementAt(1).Click();

            //used to pull numbers from a text document to use as variables

            //var dic = File.ReadAllLines("C:\\Users\\Admin\\Desktop\\variables.txt")
            //  .Select(l => l.Split(new[] { '=' }))
            //  .ToDictionary(s => s[0].Trim(), s => s[1].Trim());


        }
        public void MultiTab(int numTab)
        {
            Actions action = new Actions(this.driver);
            while (numTab > 0)
            {
                action.SendKeys(OpenQA.Selenium.Keys.Tab).Build().Perform();
                numTab--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }

        public void MultiShiftTab(int numTab)
        {
            Actions action = new Actions(this.driver);
            while (numTab > 0)
            {
                action.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.Tab).KeyUp(OpenQA.Selenium.Keys.Shift).Build().Perform();
                numTab--;
            }
            Thread.Sleep(3000);
            action.SendKeys(Keys.Enter).Perform();
        }
    }
}
