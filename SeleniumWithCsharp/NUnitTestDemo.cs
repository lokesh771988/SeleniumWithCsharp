using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWithCsharp.POM;

namespace SeleniumWithCsharp
{
    [TestFixture("mercury", "mercury")]
    [Category("Regress")]
    public class NUnitTestDemo
    {
        private IWebDriver driver;
        private string userName;
        private string password;
        public NUnitTestDemo(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("Smoke")]
        public void login()
        {
            loginPage logins = new loginPage(driver);
            logins.login(userName, password);
        }

        [Test]
        [Category("Sanity")]
        public void login1()
        {
            loginPage logins = new loginPage(driver);
            logins.login("mercury", "mercury");
        }

        [Test]
        [Category("Regress")]
        [TestCase("SheetName", "RowNumber")]
        public void testCaseDemo(string sheet, string numer)
        {
            Console.WriteLine(sheet);
            Console.WriteLine(numer);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
