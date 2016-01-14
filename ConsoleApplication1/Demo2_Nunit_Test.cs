using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{   
    class Demo2_Nunit_Test
    {

        //Instantiate a browser
        //IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            //Open System Under Test
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("http://www.trademe.co.nz/");
        }

        [Test]
        public void ExecuteTest_No_Custom_Methods()
        {
            //Recognize/Map Screen Elements
            IWebElement Searchbox = PropertiesCollection.driver.FindElement(By.XPath("//*[@id='searchString']"));
            IWebElement Searchbutton = PropertiesCollection.driver.FindElement(By.XPath("//*[@id='generalSearch']/div[2]/button"));
          
            //Perform Tests
            Console.WriteLine("Running Tests in Chrome Browser...");
            string Testdata = "Samsung Galaxy";
            Searchbox.SendKeys(Testdata);
            Searchbutton.Click();
            
            //Sync Point
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='mainContent']/h1")));
            
            //Recognize/Map Element. ** will only display after click Searchbutton
            string Searchresult1 = PropertiesCollection.driver.FindElement(By.XPath("//*[@id='mainContent']/h1/span")).Text;
            string Searchresult2 = Searchresult1.Remove(Searchresult1.LastIndexOf("'"), 1);
            string Searchresult = Searchresult2.Remove(Searchresult2.IndexOf("'"), 1);

            //Checkpoints
            Assert.AreEqual(Testdata, Searchresult);
        }


        [Test]
        public void ExecuteTest_Using_PageObjectModel()
        {
            BaseSearchPageObject page = new BaseSearchPageObject();
            page.SearchByKeyword("Samsung Galaxy");
            
        }

        [TearDown]
        public void CleanUp()
        {
            //Close System Under Test
            //driver.Close();    
        }


    }
}
