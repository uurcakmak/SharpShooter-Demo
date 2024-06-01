using OpenQA.Selenium;

namespace SharpShooterDemo.models;

public class WebElementInfo
{
    public WebElementInfo(By locator, IWebElement element)
    {
        Locator = locator;
        Element = element;
    }

    public By Locator { get; set; }
    public IWebElement Element { get; set; }
}