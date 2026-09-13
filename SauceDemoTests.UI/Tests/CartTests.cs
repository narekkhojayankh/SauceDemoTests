using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoTests.UI.Core;
using SauceDemoTests.UI.Pages;

namespace SauceDemoTests.UI.Tests
{
    [TestFixture]
    [AllureSuite("Cart")]
    public class CartTests : BaseTest
    {
        private const string SampleProductId = "sauce-labs-backpack";

        [Test]
        [AllureFeature("Add product to cart")]
        public void AddProductToCart_UpdatesCartBadgeCount()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.AddProductToCart(SampleProductId);

            Assert.That(inventoryPage.GetCartItemCount(), Is.EqualTo(1));
        }

        [Test]
        [AllureFeature("Remove product from cart")]
        public void RemoveProductFromCart_ClearsCartBadge()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.AddProductToCart(SampleProductId);
            inventoryPage.RemoveProductFromCart(SampleProductId);

            Assert.That(inventoryPage.GetCartItemCount(), Is.EqualTo(0));
        }

        [Test]
        [AllureFeature("Cart page shows added item")]
        public void OpenCart_AfterAddingProduct_ShowsOneItem()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);
            var cartPage = new CartPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.AddProductToCart(SampleProductId);
            inventoryPage.OpenCart();

            Assert.That(cartPage.GetItemsInCart(), Is.EqualTo(1));
        }
    }
}