using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoTests.UI.Core
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");

            return new ChromeDriver(options);
        }
    }
}