using OpenQA.Selenium;
using SauceDemoTests.UI.Core;

namespace SauceDemoTests.UI.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;

        private By CartBadge => By.CssSelector(".shopping_cart_badge");
        private By CartIcon => By.CssSelector(".shopping_cart_link");

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By AddToCartButton(string productId) =>
            By.CssSelector($"[data-test='add-to-cart-{productId}']");

        private By RemoveFromCartButton(string productId) =>
            By.CssSelector($"[data-test='remove-{productId}']");

        public void AddProductToCart(string productId)
        {
            Waits.UntilClickable(_driver, AddToCartButton(productId)).Click();
        }

        public void RemoveProductFromCart(string productId)
        {
            Waits.UntilClickable(_driver, RemoveFromCartButton(productId)).Click();
        }

        public int GetCartItemCount()
        {
            var badges = _driver.FindElements(CartBadge);
            if (badges.Count == 0) return 0;

            return int.Parse(badges[0].Text);
        }

        public void OpenCart()
        {
            Waits.UntilClickable(_driver, CartIcon).Click();
        }
    }
}