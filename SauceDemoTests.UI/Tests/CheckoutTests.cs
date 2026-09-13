using Allure.NUnit.Attributes;
using SauceDemoTests.UI.Core;
using SauceDemoTests.UI.Pages;

namespace SauceDemoTests.UI.Tests
{
    [TestFixture]
    [AllureSuite("Checkout")]
    public class CheckoutTests : BaseTest
    {
        private const string SampleProductId = "sauce-labs-backpack";

        [Test]
        [AllureFeature("Full checkout flow")]
        public void CompleteCheckout_WithValidData_ShowsOrderConfirmation()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);
            var cartPage = new CartPage(Driver);
            var checkoutPage = new CheckoutPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.AddProductToCart(SampleProductId);
            inventoryPage.OpenCart();
            cartPage.ClickCheckout();

            checkoutPage.FillCustomerInfo("Jhon", "Smith", "0010");
            checkoutPage.ClickContinue();

            Assert.That(checkoutPage.GetTotalText(), Does.StartWith("Total:"));

            checkoutPage.ClickFinish();

            Assert.That(checkoutPage.GetConfirmationText(), Is.EqualTo("Thank you for your order!"));
        }
    }
}