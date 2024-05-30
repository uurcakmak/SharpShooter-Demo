using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;

using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using SharpShooterDemo.Utilities;

namespace SharpShooterDemo
{
    public class StepImplementation
    {
        [Step("Open the browser and navigate to <url>")]
        public void OpenBrowser(string url)
        {
            Driver.Initialize();
            Driver.WebDriver.Navigate().GoToUrl(url);
        }

        [Step("Close the browser")]
        public void CloseBrowser()
        {
            Driver.CleanUp();
        }

        [Step("Check that the page title is <title>")]
        public void CheckPageTitle(string title)
        {
            string pageTitle = Driver.WebDriver.Title;
            if (!pageTitle.Equals(title))
            {
                throw new Exception($"Expected title {title}, but got {pageTitle}");
            }
        }
    }
}
