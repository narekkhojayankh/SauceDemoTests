using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.UI.Core
{
    public static class Waits
    {
        private const int DefaultTimeoutSeconds = 10;

        public static IWebElement UntilVisible(IWebDriver driver, By locator, int timeoutSec = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            })!;
        }

        public static IWebElement UntilClickable(IWebDriver driver, By locator, int timeoutSec = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed && element.Enabled) ? element : null;
            })!;
        }

        public static void UntilUrlContains(IWebDriver driver, string fragment, int timeoutSec = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(d => d.Url.Contains(fragment));
        }
    }
}