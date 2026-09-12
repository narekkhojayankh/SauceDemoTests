using Allure.Net.Commons;
using OpenQA.Selenium;

namespace SauceDemoTests.UI.Helpers
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Directory.CreateDirectory("allure-results");
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filePath = Path.Combine("allure-results", $"{Guid.NewGuid()}.png");
            screenshot.SaveAsFile(filePath);
            AllureApi.AddAttachment("Screenshot", "image/png", filePath);
        }
    }
}