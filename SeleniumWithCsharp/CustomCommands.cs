using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWithCsharp
{
    public class CustomCommands
    {
        public static void click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void click(IWebElement locator)
        {
            locator.Click();
        }

        public static void enterValue(IWebDriver driver, By locator, string value)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(value);
        }

        public static void enterValue(IWebElement locator, string value)
        {
            locator.Clear();
            locator.SendKeys(value);
        }

        public static void selectDropdownValues(IWebDriver driver, By locator, string condition, int number, string value)
        {
            IWebElement element = driver.FindElement(locator);
            SelectElement option = new SelectElement(element);
            switch (condition)
            {
                case "indix":            
                    option.SelectByIndex(number);
                    break;
                case "value":                
                    option.SelectByValue(value);
                    break;
                case "text":
                    option.SelectByText(value);
                    break;
            }
        }
        public static void dynmaicDropdownSelectValue(IWebDriver driver, By locator, string text)
        {
            IList<IWebElement> element = driver.FindElements(locator);

            for (int i = 0; i < element.Count; i++)
            {
                string value = element[i].Text;
                Console.WriteLine(value);
                if (value.Contains(text))
                {
                    element[i].Click();
                    break;
                }
            }
        }

       public static void actionClass(IWebDriver driver, By locator, string condition, string alertMessage)
        {
            Actions actions = new Actions(driver);
            IWebElement element = driver.FindElement(locator);
            //IAlert alert = driver.SwitchTo().Alert();
            
            
            switch (condition)
            {
                case "doubleClick":
                    actions.DoubleClick(element).Perform();
                    IAlert alert = driver.SwitchTo().Alert();
                    Thread.Sleep(2000);
                    string text = alert.Text;
                    Assert.AreEqual(text, alertMessage);
                    alert.Accept();
                    break;
                case "rightClick":
                    actions.ContextClick(element).Perform();

                    //Thread.Sleep(2000);
                    //string text1 = alert.Text;
                    //Assert.AreEqual(text1, alertMessage);
                    break;
                
            }
        }
    }
}
