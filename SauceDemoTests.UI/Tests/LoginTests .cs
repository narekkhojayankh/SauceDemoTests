using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoTests.UI.Core;
using SauceDemoTests.UI.Pages;

namespace SauceDemoTests.UI.Tests
{
    [TestFixture]
    [AllureSuite("Login")]
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureFeature("Successful login")]
        public void Login_WithValidCredentials_RedirectsToInventoryPage()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(Driver.Url, Does.Contain("inventory.html"));
        }

        [Test]
        [AllureFeature("Invalid password")]
        public void Login_WithWrongPassword_ShowsErrorMessage()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Login("standard_user", "wrong_password");

            Assert.That(loginPage.GetErrorText(), Does.Contain("Username and password do not match"));
        }

        [Test]
        [AllureFeature("Locked out user")]
        public void Login_WithLockedOutUser_ShowsLockedOutMessage()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Login("locked_out_user", "secret_sauce");

            Assert.That(loginPage.GetErrorText(), Does.Contain("locked out"));
        }
    }
}