using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using OpenQA.Selenium.Support;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using System.Collections.Generic;
using SharpShooterDemo.models;

namespace SharpShooterDemo.Utilities
{
    public static class Driver
    {
        private static IWebDriver _webDriver;

        public static IWebDriver WebDriver => _webDriver;

        public static bool Headless { get; set; } = false;

        public static void Back()
        {
            _webDriver.Navigate().Back();
        }

        public static void CleanUp()
        {
            _webDriver.Quit();
        }

        public static void ClearTextBox(IWebElement element)
        {
            element.Clear();
        }

        public static void ClickElement(WebElementInfo elmInfo)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elmInfo.Locator));
            elmInfo.Element.Click();
        }

        public static void DoubleClickElement(IWebElement element)
        {
            Actions action = new Actions(_webDriver);
            action.DoubleClick(element).Perform();
        }

        public static bool ElementExists(By by)
        {
            try
            {
                _webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool ElementExists(string name)
        {
            return ElementExists(By.Name(name));
        }

        public static bool ElementExistsByClassName(string className)
        {
            return ElementExists(By.ClassName(className));
        }

        public static bool ElementExistsByCss(string css)
        {
            return ElementExists(By.CssSelector(css));
        }

        public static bool ElementExistsById(string id)
        {
            return ElementExists(By.Id(id));
        }

        public static void Forward()
        {
            _webDriver.Navigate().Forward();

        }
        public static void SwitchToFrame(IWebElement element)
        {
            _webDriver.SwitchTo().Frame(element);
        }

        public static string GetElementAttribute(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public static string GetElementTagName(IWebElement element)
        {
            return element.TagName;
        }

        public static string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public static IWebElement GetElementById(string id)
        {
            return _webDriver.FindElement(By.Id(id));
        }

        public static IWebElement GetElementByName(string name)
        {
            return _webDriver.FindElement(By.Name(name));
        }

        public static IWebElement GetElementByClassName(string className)
        {
            return _webDriver.FindElement(By.ClassName(className));
        }

        public static IWebElement GetElementByCss(string css)
        {
            return _webDriver.FindElement(By.CssSelector(css));
        }
        public static IWebElement GetElementBy(By by)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));

            var element = _webDriver.FindElement(by);

            return element;
        }

        public static ReadOnlyCollection<IWebElement> GetElementsBy(By by)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            elements = _webDriver.FindElements(by);

            return elements;
        }

        public static string GetTextBoxValue(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void Initialize(bool headless = false)
        {
            Headless = headless;
            var driverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("window-size=1920,1080"); // Set a fixed window size
            options.AddArgument("disable-gpu"); // Applicable to Windows OS
            _webDriver = new ChromeDriver(driverPath, options);
        }

        public static bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public static bool IsElementEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public static bool IsElementSelected(IWebElement element)
        {
            return element.Selected;
        }

        public static void MaximizeWindow()
        {
            _webDriver.Manage().Window.Maximize();
        }

        public static void MinimizeWindow()
        {
            _webDriver.Manage().Window.Minimize();
        }

        public static void NavigateTo(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public static void Refresh()
        {
            _webDriver.Navigate().Refresh();
        }

        public static void RightClickElement(IWebElement element)
        {
            Actions action = new Actions(_webDriver);
            action.ContextClick(element).Perform();
        }

        public static void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public static void ScrollToTop()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public static void SetSelect2Value(IWebElement element, string value)
        {
            element.Click();
            element.SendKeys(value);
            element.SendKeys(Keys.Enter);
        }

        public static void SetTextBoxValue(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void SubmitPage()
        {
            _webDriver.FindElement(By.TagName("form")).Submit();
        }

        public static void SetWindowSize(int width, int height)
        {
            _webDriver.Manage().Window.Size = _webDriver.Manage().Window.Size with { Height = height, Width = width };
        }

        public static void SetZoom(int zoomLevel = 100)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript($"document.body.style.zoom='{zoomLevel}%'");
        }
    }
}