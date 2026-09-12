using OpenQA.Selenium;
using SauceDemoTests.UI.Core;

namespace SauceDemoTests.UI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        private By UsernameInput => By.Id("user-name");
        private By PasswordInput => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterUsername(string username)
        {
            Waits.UntilVisible(_driver, UsernameInput).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Waits.UntilVisible(_driver, PasswordInput).SendKeys(password);
        }

        public void ClickLogin()
        {
            Waits.UntilClickable(_driver, LoginButton).Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public string GetErrorText()
        {
            return Waits.UntilVisible(_driver, ErrorMessage).Text;
        }
    }
}