using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Demo1_Console_Test
    {

        static void Main(string[] args)
        {
            //Instantiate a browser

            IWebDriver driver = new ChromeDriver();

            //Open System Under Test
            driver.Navigate().GoToUrl("http://www.google.com");

            //Recognize/Map Screen Elements
            IWebElement Searchbox = driver.FindElement(By.Name("q"));

            //Perform Tests
            Console.WriteLine("Running Tests in Chrome Browser...");
            Searchbox.SendKeys("Planit Software Testing");

            //Close System Under Test
            //driver.Close();
        }

    }
}
