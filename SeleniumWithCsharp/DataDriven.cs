using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumWithCsharp.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SeleniumWithCsharp
{
    public class DataDriven
    {
        private IWebDriver driver;
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("DataDriven")]
        [TestCaseSource(nameof(loginMo))]
        public void login(LoginModel login)
        {
            loginPage logins = new loginPage(driver);
            logins.login(login.UserName, login.Password);
        }

        public static IEnumerable<LoginModel> loginMo()
        {
            yield return new LoginModel()
            {
                UserName = "mercury",
                Password = "mercury"
            };

            yield return new LoginModel()
            {
                UserName = "mercury",
                Password = "mercury"
            };

            yield return new LoginModel()
            {
                UserName = "mercury",
                Password = "mercury"
            };
        }

        [Test]
        [Category("DataDriven")]
        [TestCaseSource(nameof(readJson))]
        public void loginWithJson(LoginModel login)
        {
            loginPage logins = new loginPage(driver);
            logins.login(login.UserName, login.Password);
        }

        public static IEnumerable<LoginModel> readJson()
        {
            string filePath = @"C:\Users\lokesh_gorantla\source\repos\SeleniumWithCsharp\SeleniumWithCsharp\JsonData.json";
            var jsonString = File.ReadAllText(filePath);
            //var loginModels = JsonSerializer.Deserialize<LoginModel>(jsonString);
            var loginModels = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            //Console.WriteLine($"Username: {loginModel.UserName},  Passowrd: {loginModel.Password}");
            foreach (var loginData in loginModels)
            {
                yield return loginData;
            }
            //yield return loginData;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
