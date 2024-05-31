using System;
using System.Threading;
using Gauge.CSharp.Lib.Attribute;
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

        [Step("Close the browser",
            "Tarayıcıyı kapat")]
        public void CloseBrowser()
        {
            Driver.CleanUp();
        }
    }
}
