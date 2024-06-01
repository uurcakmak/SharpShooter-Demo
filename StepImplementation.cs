using System;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using SharpShooterDemo.models;
using SharpShooterDemo.Utilities;

namespace SharpShooterDemo
{
    public class StepImplementation
    {
        [BeforeSpec]
        public void BeforeSpec()
        {
            Driver.Initialize();
        }

        [AfterSpec]
        public void AfterSuite()
        {
            //Driver.CleanUp();
        }

        [Step("Go back", "Geri git")]
        public void GoBack()
        {
            Driver.Back();
        }

        [Step("Go forward", "İleri git")]
        public void GoForward()
        {
            Driver.Forward();
        }

        [Step("Minimize window", "Simge durumuna küçült")]
        public void MinimizeWindow()
        {
            Driver.MinimizeWindow();
        }

        [Step("Maximize window", "Ekranı kapla")]
        public void MaximizeWindow()
        {
            Driver.MaximizeWindow();
        }

        [Step("Scroll to bottom", "Ekranın sonuna git")]
        public void ScrollToBottom()
        {
            Driver.ScrollToBottom();
        }

        [Step("Scroll to element by <id>")]
        public void ScrollToElementById(string id)
        {
            Driver.ScrollToBottom();
        }

        [Step("Scroll to top", "Ekranın başına git")]
        public void ScrollToTop()
        {
            Driver.ScrollToTop();
        }

        [Step("Check element by name <name>",
            "Name değeri <name> olan element var mı kontrol et")]
        public void CheckElementExistsByName(string name)
        {
            Driver.ElementExists(name);
        }

        [Step("Check element by id <id>",
            "Id değeri <id> olan element var mı kontrol et")]
        public void CheckElementExistsById(string id)
        {
            Driver.ElementExistsById(id);
        }

        [Step("Check element by class <classname>",
            "Class değeri <classname> olan element var mı kontrol et")]
        public void CheckElementExistsByClass(string classname)
        {
            Driver.ElementExistsByClassName(classname);
        }

        [Step("Check element by css <css>",
            "Css değeri <css> olan element var mı kontrol et")]
        public void CheckElementExistsByCss(string css)
        {
            Driver.ElementExistsByCss(css);
        }

        [Step("Clear textbox by id <id>",
            "Id değeri <id> olan textbox ı temizle")]
        public void ClearTextbox(string id)
        {
            var elm = Driver.GetElementById(id);
            Driver.ClearTextBox(elm);
        }

        [Step("Find element with id <id> and set it's value to <value>")]
        public void SetTextbox(string id, string value)
        {
            var elm = Driver.GetElementById(id);
            Driver.SetTextBoxValue(elm, value);
        }

        [Step("Find element with name <name> and set it's value to <value>")]
        public void SetTextboxByName(string name, string value)
        {
            var elm = Driver.GetElementByName(name);
            Driver.SetTextBoxValue(elm, value);
        }

        [Step("Submit page")]
        public void SubmitPage()
        {
            Driver.SubmitPage();
        }

        [Step("Open the browser and navigate to <url>",
            "Tarayıcıyı aç ve <url> adresine git")]
        public void NavigateTo(string url)
        {
            Driver.NavigateTo(url);
        }

        [Step("Navigate to <url>",
            "<url> adresine git")]
        public void NavigateToPage(string url)
        {
            Driver.NavigateTo(url);
        }

        [Step("Set zoom to default",
            "Zoom değerini sıfırla")]
        public void ClearZoom()
        {
            Driver.SetZoom();
        }

        [Step("Set zoom to <value>%",
            "Zoom değerini %<value> olarak ayarla")]
        public void SetZoom(int value)
        {
            Driver.SetZoom(value);
        }

        [Step("Wait for <duration> seconds",
            "<duration> saniye bekle")]
        public void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        [Step("Reload the current page",
            "Mevcut sayfayı yenile")]
        public void RefreshBrowser()
        {
            Driver.Refresh();
        }

        [Step("Check that the page title is <title>",
            "Sayfanın başlığının <title> olduğunu teyit et")]
        public void CheckPageTitle(string title)
        {
            string pageTitle = Driver.WebDriver.Title;
            if (!pageTitle.Equals(title))
            {
                throw new Exception($"Expected title {title}, but got {pageTitle}");
            }
        }

        [Step("Click on element by id <id>")]
        public void ClickOnElementById(string id)
        {
            var element = Driver.GetElementById(id);
            var elmInfo = new WebElementInfo(By.Id(id), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Click on element by id <id> inside iframe by selector <selector>")]
        public void ClickOnElementByIdInsideIframe(string id, string selector)
        {
            var iframe = Driver.GetElementByCss(selector);
            Driver.SwitchToFrame(iframe);

            var element = Driver.GetElementById(id);
            var elmInfo = new WebElementInfo(By.Id(id), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Click on element by name <name>")]
        public void ClickOnElementByName(string name)
        {
            var element = Driver.GetElementByName(name);
            var elmInfo = new WebElementInfo(By.Name(name), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Click on element by class <className>")]
        public void ClickOnElementByClass(string className)
        {
            var element = Driver.GetElementByClassName(className);
            var elmInfo = new WebElementInfo(By.ClassName(className), element);
            Driver.ClickElement(elmInfo);
        }


        [Step("Click on element by selector <selector>")]
        public void ClickOnElementBySelector(string selector)
        {
            var element = Driver.GetElementsBy(By.CssSelector(selector)).First();
            var elmInfo = new WebElementInfo(By.CssSelector(selector), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Click on element by css <css>")]
        public void ClickOnElementByCss(string css)
        {
            var element = Driver.GetElementByCss(css);
            var elmInfo = new WebElementInfo(By.CssSelector(css), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Find elements by selector <selector> and click on the element at index <position>")]
        public void FindElementsAndClickOnOne(string selector, string position)
        {
            var elements = Driver.GetElementsBy(By.CssSelector(selector));
            var element = elements[Convert.ToInt32(position) - 1];

            var elmInfo = new WebElementInfo(By.CssSelector(selector), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Find element by selector <selector> and click")]
        public void FindElementAndClick(string selector)
        {
            var element = Driver.GetElementBy(By.CssSelector(selector));
            var elmInfo = new WebElementInfo(By.CssSelector(selector), element);
            Driver.ClickElement(elmInfo);
        }

        [Step("Close the browser",
            "Tarayıcıyı kapat")]
        public void CloseBrowser()
        {
            Driver.CleanUp();
        }
    }
}
