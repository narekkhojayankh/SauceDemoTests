using Allure.NUnit;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauceDemoTests.UI.Config;
using SauceDemoTests.UI.Helpers;

namespace SauceDemoTests.UI.Core
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; } = null!;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.GetDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(Driver);
            }

            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}