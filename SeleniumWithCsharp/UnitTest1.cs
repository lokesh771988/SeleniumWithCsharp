using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SeleniumWithCsharp.POM;

namespace SeleniumWithCsharp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement element = driver.FindElement(By.Id("APjFqb"));
            // clearing text in textbox
            element.Clear();
            // entering value into textbox
            element.SendKeys("selenium");
            element.SendKeys(Keys.Return);
        }

        [Test]
        public void LocatorsDemo1()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            // locator - Name
            //IWebElement element = driver.FindElement(By.Name("q"));
            //IWebElement element = driver.FindElement(By.ClassName("gLFyf"));
            //IWebElement element = driver.FindElement(By.LinkText("REGISTER"));
            IWebElement element = driver.FindElement(By.PartialLinkText("REGI"));
            // clearing text in textbox
            //element.Clear();
            // entering value into textbox
            //element.SendKeys("selenium");
            //element.SendKeys(Keys.Return);
            element.Click();
        }

        [Test]
        public void LocatorsDemo2()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            //IWebElement element = driver.FindElement(By.XPath("//textarea[@title='Search']"));
            //IWebElement element = driver.FindElement(By.XPath("//button[contains(text(),' Submit ')]"));
            IWebElement element = driver.FindElement(By.XPath("//button[contains(text(),' Submit ')]"));
            // clearing text in textbox
            //element.Clear();
            // entering value into textbox
            //element.SendKeys("selenium");
            //element.SendKeys(Keys.Return);
            element.Click();
        }

        [Test]
        public void LocatorsDemo3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            //driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            //IWebElement element = driver.FindElement(By.CssSelector("#APjFqb"));
            //IWebElement element = driver.FindElement(By.CssSelector(".gLFyf"));
            IWebElement element = driver.FindElement(By.CssSelector("[name=\"q\"]"));
            // clearing text in textbox
            element.Clear();
            // entering value into textbox
            element.SendKeys("selenium");
            element.SendKeys(Keys.Return);
            //element.Click();
            
        }

        [Test]
        public void LocatorsDemo4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            //above
            //var emailLocator = RelativeBy.WithLocator(By.TagName("input")).Above(By.CssSelector("[ng-model=\"Adress\"]"));
            // Below
            //var passwordLocator = RelativeBy.WithLocator(By.TagName("input")).Below(By.CssSelector("[ng-model=\"Adress\"]"));
            //to left
            //var cancelLocator = RelativeBy.WithLocator(By.TagName("input")).LeftOf(By.CssSelector("[placeholder=\"Last Name\"]"));
            //To Right
            var submitLocator = RelativeBy.WithLocator(By.TagName("input")).RightOf(By.CssSelector("[placeholder=\"First Name\"]"));
            //Near
            //var emailLocator = RelativeBy.WithLocator(By.TagName("input")).Near(By.CssSelector("placeholder=\"First Name\""));
            driver.FindElement(submitLocator).SendKeys("Lokesh");
        }

        [Test]
        public void WebDriverCommands()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            String title = driver.Title;
            Console.Write(title);
            Assert.AreEqual(title, "Google", "both Title are not equals");

            String urls = driver.Url;
            Assert.AreEqual(urls, "https://www.google.com/", "both URL are not equals");

            //driver.Close();
            driver.Quit();
        }

        [Test]
        public void WebDriverCommandsWithCloseAndQuite()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Windows.html");

            driver.FindElement(By.XPath("//*[text()='    click   ']")).Click();
            //driver.Close();
            driver.Quit();
        }

        [Test]
        public void WebDriverNavigational()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Windows.html");
            String title = driver.Title;
            Console.WriteLine(title);
            Assert.AreEqual(title, "Frames & windows", "both Title are not equals");

            driver.Navigate().GoToUrl("https://www.google.com/");
            String title1 = driver.Title;
            Console.WriteLine(title1);
            Assert.AreEqual(title1, "Google", "both Title are not equals");
            driver.Navigate().Back();
            String title2 = driver.Title;
            Console.WriteLine(title2);
            Assert.AreEqual(title2, "Frames & windows", "both Title are not equals");
            driver.Navigate().Forward();
            String title3 = driver.Title;
            Console.WriteLine(title3);
            Assert.AreEqual(title3, "Google", "both Title are not equals");
            driver.Navigate().Refresh();
        }

        [Test]
        public void WebDriverConditional()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            IWebElement el = driver.FindElement(By.CssSelector("[placeholder=\"First Name\"]"));
            IWebElement element = driver.FindElement(By.Id("checkbox1"));
            if (el.Displayed)
            {
                Console.WriteLine("Element is displayed");
                Assert.IsTrue(el.Displayed, "element is not visible");
                Assert.IsTrue(el.Enabled, "Element is not enabled");
                Assert.IsFalse(element.Selected, "Element is not selected");

            }
            else
            {
                Console.WriteLine("Element is not displayed");
            }

            element.Click();
            Assert.IsTrue(element.Selected, "Element is not selected");
            driver.Close();
        }

        [Test]
        public void WaitsInWebDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            //implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement el = driver.FindElement(By.CssSelector("[placeholder=\"First Name\"]"));
            //explicit wait
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(d => el.Displayed);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
                Message = "Element is not visible"
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(d => {
                el.SendKeys("Displayed");
                return true;
            });

            DefaultWait<IWebDriver> fluent = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(2),
                PollingInterval = TimeSpan.FromMilliseconds(300),
                Message = "Element is not visible"
            };

            fluent.IgnoreExceptionTypes(typeof(NoSuchElementException));

            fluent.Until(d => {
                el.SendKeys("Displayed");
                return true;
            });

            IWebElement element = driver.FindElement(By.Id("checkbox1"));
            if (el.Displayed)
            {
                Console.WriteLine("Element is displayed");
                Assert.IsTrue(el.Displayed, "element is not visible");
                Assert.IsTrue(el.Enabled, "Element is not enabled");
                Assert.IsFalse(element.Selected, "Element is not selected");

            }
            else
            {
                Console.WriteLine("Element is not displayed");
            }

            element.Click();
            Assert.IsTrue(element.Selected, "Element is not selected");
            driver.Close();
        }

        [Test]
        public void RadioAndCheckBox()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            //IWebElement element = driver.FindElement(By.XPath("//input[@value=\"Male\"]"));
            //element.Click();
            //Assert.IsTrue(element.Selected, "Element is not selected");

            IList<IWebElement> list = driver.FindElements(By.XPath("//input[@name=\"radiooptions\"]"));

            for(int i = 0; i < list.Count; i++)
            {
                String name = list[i].GetAttribute("value");
                if (name == "FeMale")
                {
                    list[i].Click();
                    Assert.IsTrue(list[i].Selected, "Element is not selected");
                    break;
                }

                if (name == "Male")
                {
                    list[i].Click();
                    Assert.IsTrue(list[i].Selected, "Element is not selected");
                    break;
                }
            }

            IList<IWebElement> list1 = driver.FindElements(By.CssSelector("[type=\"checkbox\"]"));

            for (int i = 0; i < list1.Count; i++)
            {
                String name = list1[i].GetAttribute("value");
                if (!list1[i].Selected)
                {
                    list1[i].Click();
                    Assert.IsTrue(list1[i].Selected, "Element is not selected");
                }

            }
            driver.Close();
        }

        [Test]
        public void TextBoxHandle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");

            IWebElement element = driver.FindElement(By.CssSelector("[placeholder=\"First Name\"]"));

            element.Clear();
            Assert.IsTrue(element.Displayed, "Element is not disaplyed");
            Assert.IsTrue(element.Enabled, "ELement is not Enabled");

            element.SendKeys("Lokesh");

            string textValue = element.GetAttribute("value");

            if (!string.IsNullOrEmpty(textValue))
            {
                Console.WriteLine("Textbox is having value");
            }
            else{
                Console.WriteLine("Textbox is not having value");
            }
        }

        [Test]
        public void AlertsHandle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            //accept alert
            //driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();

            //driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']")).Click();
            //driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']")).Click();
            CustomCommands.click(driver, By.XPath("//button[text()='Click for JS Prompt']"));
            
            IAlert alert = driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.SendKeys("lokesh");
            alert.Accept();
            //alert.Dismiss();
            IWebElement element = driver.FindElement(By.Id("result"));
            //Assert.AreEqual(text, "I am a JS Alert");
            //Assert.AreEqual(element.Text, "You successfully clicked an alert");

            //Assert.AreEqual(text, "I am a JS Confirm");
            //Assert.AreEqual(element.Text, "You clicked: Cancel");

            Assert.AreEqual(text, "I am a JS prompt");
            Assert.AreEqual(element.Text, "You entered: lokesh");
            driver.Close();


        }

        [Test]
        public void DropdownValue()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");

            IWebElement element = driver.FindElement(By.Id("Skills"));

            SelectElement selectOption = new SelectElement(element);

            //option.SelectByText("C++");
            //option.SelectByValue("Backup Management");
            //option.SelectByIndex(3);
            IList<IWebElement> list = selectOption.Options;

            for(int i =0; i < list.Count; i++)
            {
                string value = list[i].Text;
                if(value == "Content Managment")
                {
                    list[i].Click();
                    break;
                }
                Console.WriteLine(value);
            }
        }

        [Test]
        public void MultiDropdown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");

            IWebElement element = driver.FindElement(By.Id("colors"));

            SelectElement selectOption = new SelectElement(element);

            selectOption.SelectByText("Red");
            selectOption.SelectByValue("blue");
            selectOption.DeselectByValue("red");
            //option.SelectByIndex(3);
        }

        [Test]
        public void DynamicDropdown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            CustomCommands.click(driver, By.XPath("//*[@data-cy='closeModal']"));
            //driver.FindElement(By.XPath("//*[@data-cy='closeModal']")).Click();
            CustomCommands.click(driver, By.Id("fromCity"));
            //driver.FindElement(By.Id("fromCity")).Click();
            Thread.Sleep(1000);
            CustomCommands.enterValue(driver, By.XPath("//*[@placeholder='From']"), "mumb");
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@placeholder='From']")).SendKeys("mumb");
            CustomCommands.dynmaicDropdownSelectValue(driver, By.XPath("//ul[@role='listbox']/li"), "BOM");
            /*IList<IWebElement> element = driver.FindElements(By.XPath("//ul[@role='listbox']/li"));

            for(int i = 0; i < element.Count; i++)
            {
                string value = element[i].Text;
                Console.WriteLine(value);
                if (value.Contains("BOM"))
                {
                    element[i].Click();
                    break;
                }
            }*/
        }

        [Test]
        public void Frames()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ui.vision/demo/webtest/frames/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IList<IWebElement> iframes = driver.FindElements(By.TagName("frame"));
            /*
            Console.WriteLine("Number of Iframes in page ::: " + iframes.Count);
            
            foreach(var iframe in iframes)
            {
                Console.WriteLine("Iframes in page ::: " + iframe.GetAttribute("src"));
            }
            */
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.Name("mytext1")).SendKeys("lokesh");
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);
            driver.FindElement(By.Name("mytext2")).SendKeys("lokesh");
        }

        [Test]
        public void MultipleWindows()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.FindElement(By.XPath("//button[text()='New Browser Window']")).Click();

            Thread.Sleep(2000);

            //parent window value
            string parentWindow = driver.CurrentWindowHandle;

            var childWindows = driver.WindowHandles;
            
            foreach(var window in childWindows)
            {
                if(window != parentWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
                
            }
            Console.WriteLine("child url ::: " + driver.Url);
            driver.SwitchTo().Window(parentWindow);
            Console.WriteLine("parent url ::: " + driver.Url);
        }

        [Test]
        public void RightClickAndDoubleClick()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/simple_context_menu.html");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            CustomCommands.actionClass(driver, By.XPath("//button[text()='Double-Click Me To See Alert']"), "doubleClick", "You double clicked me.. Thank You..");
            CustomCommands.actionClass(driver, By.XPath("//*[text()='right click me']"), "rightClick", "clicked: paste");
            /*IWebElement doubleclick = driver.FindElement(By.XPath("//button[text()='Double-Click Me To See Alert']"));
            IWebElement rightclick = driver.FindElement(By.XPath("//*[text()='right click me']"));
            IWebElement element = driver.FindElement(By.XPath("//*[text()='Paste']"));
            Actions actions = new Actions(driver);

            //double click
            
            actions.DoubleClick(doubleclick).Perform();

            
            Thread.Sleep(2000);
            string text = alert.Text;
            Assert.AreEqual(text, "You double clicked me.. Thank You..");
            alert.Accept();
            
            //right click
            actions.ContextClick(rightclick).Perform();
            actions.Click(element).Perform();
            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(2000);
            string text1 = alert.Text;
            Assert.AreEqual(text1, "clicked: paste");
            alert.Accept();
            */
        }

        [Test]
        public void hover()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement moveElement = driver.FindElement(By.XPath("//a[text()='SwitchTo']"));
            IWebElement AlertsElement = driver.FindElement(By.XPath("//a[text()='Alerts']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(moveElement).Perform();
            actions.MoveToElement(AlertsElement).Perform();
        }

        [Test]
        public void dragAndDrop()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement target = driver.FindElement(By.Id("droppable"));
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, target).Perform();
        }

        [Test]
        public void ScreenshotEx()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element = driver.FindElement(By.Name("submit"));

            //Full Screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = "C:\\Users\\lokesh_gorantla\\source\\repos\\SeleniumWithCsharp\\SeleniumWithCsharp\\FullImage.png";

            screenshot.SaveAsFile(filePath);

            using(Bitmap fullImage = new Bitmap(filePath))
            {
                var location = element.Location;
                var size = element.Size;
                using (Bitmap elementImage = fullImage.Clone(new Rectangle(location.X, location.Y, size.Width, size.Height), fullImage.PixelFormat))
                {
                    string elementScreen = "C:\\Users\\lokesh_gorantla\\source\\repos\\SeleniumWithCsharp\\SeleniumWithCsharp\\ElementImage.png";
                    elementImage.Save(elementScreen);
                }
            }
        }

        [Test]
        public void ScrollDown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element = driver.FindElement(By.Id("submitbtn"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //executor.ExecuteScript("window.scrollBy(0,500);");
            //executor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            element.SendKeys(Keys.PageDown);
        }


        [Test]
        public void Webtable()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            // rows count
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("[name=\"BookTable\"] > tbody > tr"));
            Console.WriteLine("Rows Count :: " + rows.Count);
            IList<IWebElement> columns = driver.FindElements(By.CssSelector("[name=\"BookTable\"] > tbody > tr > th"));
            Console.WriteLine("Columns count ::; " + columns.Count);
            //string text = driver.FindElement(By.CssSelector("[name=\"BookTable\"] > tbody > tr:nth-child(2) > td:nth-child(1)")).Text;
            //Console.WriteLine(text);

            for(var i = 2; i <= rows.Count; i++)
            {
                for(var j = 1; j <= columns.Count; j++)
                {
                    var cellValue = driver.FindElement(By.CssSelector("[name=\"BookTable\"] > tbody > tr:nth-child("+i+") > td:nth-child("+j+")")).Text;
                    Console.WriteLine(cellValue);
                }
                Console.WriteLine("    ");
            }

            driver.Quit();
        }

        [Test]
        public void WebtablePagination()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            // rows count
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("#productTable > tbody > tr"));
            Console.WriteLine("Rows Count :: " + rows.Count);
            IList<IWebElement> columns = driver.FindElements(By.CssSelector("#productTable > thead > tr > th"));
            Console.WriteLine("Columns count ::; " + columns.Count);
            var flag = false;
            for(var i = 1; i <= columns.Count; i++)
            {
                driver.FindElement(By.XPath("//a[text()="+i+"]")).Click();
                Thread.Sleep(1000);
                for(var j = 1; j <= rows.Count; j++)
                {
                    for(var k = 1; k <=3; k++)
                    {
                        string text = driver.FindElement(By.CssSelector("#productTable > tbody > tr:nth-child("+j+") > td:nth-child("+k+")")).Text;
                        Console.WriteLine(text);
                        if (text.Contains("Router"))
                        {
                            flag = true;
                            driver.FindElement(By.CssSelector("#productTable > tbody > tr:nth-child(" + j + ") > td > input")).Click();
                            break;
                        }
                       if(flag == true)
                        {
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }
            }
            Thread.Sleep(2000);  
            //driver.Quit();
        }

        [Test]
        public void TC24_Upload()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element = driver.FindElement(By.Id("file-upload"));
            var path = @"C:\Users\lokesh_gorantla\Downloads\Playwright.png";
            element.SendKeys(path);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("file-submit")).Click();
            Thread.Sleep(1000);
            var text = driver.FindElement(By.Id("uploaded-files")).Text;
            Assert.AreEqual(text.Trim(), "Playwright.png");
        }

        [Test]
        public void TC25_Upload()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://davidwalsh.name/demo/multiple-file-upload.php");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element = driver.FindElement(By.Id("filesToUpload"));
            var path = @"C:\Users\lokesh_gorantla\Downloads\Playwright.png" + "\n" +
                "C:\\Users\\lokesh_gorantla\\Downloads\\onlineFraud1.jpg";
            element.SendKeys(path);
            Thread.Sleep(1000);
            var text = driver.FindElement(By.CssSelector("#fileList > li:nth-child(2)")).Text;
            Assert.AreEqual(text.Trim(), "onlineFraud1.jpg");
        }

        [Test]
        public void customeCommands()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            // IWebElement element = driver.FindElement(By.XPath("//input[@value=\"Male\"]"));
            //element.Click();
            Thread.Sleep(1000);
            CustomCommands.click(driver, By.XPath("//input[@value=\"male\"]"));
            Thread.Sleep(1000);
            CustomCommands.enterValue(driver, By.Id("name"), "Testing");
            Thread.Sleep(1000);
            CustomCommands.selectDropdownValues(driver, By.Id("country"), "value", 1, "germany");
            Thread.Sleep(1000);
            CustomCommands.selectDropdownValues(driver, By.Id("country"), "text", 1, "India");
        }

        [Test]
        public void Pom()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            loginPage logins = new loginPage(driver);
            logins.login("mercury", "mercury");
            /*driver.FindElement(By.Name("userName")).SendKeys("mercury");
            driver.FindElement(By.Name("password")).SendKeys("mercury");
            driver.FindElement(By.Name("submit")).Click();
            */
        }

        [Test]
        public void Pom1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            loginPage logins = new loginPage(driver);
            logins.login("mercury", "mercury");
            /*driver.FindElement(By.Name("userName")).SendKeys("mercury");
            driver.FindElement(By.Name("password")).SendKeys("mercury");
            driver.FindElement(By.Name("submit")).Click();
            */
        }
    }
}