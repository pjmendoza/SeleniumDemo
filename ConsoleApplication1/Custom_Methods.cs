using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Custom_Methods
    {
        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void Click(IWebElement element)
        {
            element.Click();
        }
        
        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static string TrimResults(string Searchresult1)
        {
            string Searchresult2 = Searchresult1.Remove(Searchresult1.LastIndexOf("'"), 1);
            string Searchresult = Searchresult2.Remove(Searchresult2.IndexOf("'"), 1);
            
            return Searchresult;
        }

        public static void WaitForObject(By element)
        {
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
        
    }
}
