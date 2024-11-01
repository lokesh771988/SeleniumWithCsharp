using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWithCsharp.POM
{
    public class loginPage
    {
        private readonly IWebDriver driver;
        public loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement userName => driver.FindElement(By.Name("userName"));

        IWebElement password => driver.FindElement(By.Name("password"));

        IWebElement submit => driver.FindElement(By.Name("submit"));

        public void login(string username, string pws)
        {
            CustomCommands.enterValue(userName, username);
            CustomCommands.enterValue(password, username);
            CustomCommands.click(submit);
            //userName.SendKeys(username);
            //password.SendKeys(pws);
            //submit.Click();
        }
    }
}
