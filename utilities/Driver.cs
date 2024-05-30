using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace SharpShooterDemo.Utilities
{
    public static class Driver
    {
        private static IWebDriver _webDriver;

        public static void Initialize()
        {
            var driverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");
            _webDriver = new ChromeDriver(driverPath);
        }

        public static IWebDriver WebDriver => _webDriver;

        public static void CleanUp()
        {
            _webDriver.Quit();
        }
    }
}