using OpenQA.Selenium;
using SauceDemoTests.UI.Core;

namespace SauceDemoTests.UI.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        private By CartItems => By.CssSelector(".cart_item");
        private By CheckoutButton => By.Id("checkout");
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public int GetItemsInCart()
        {
            return _driver.FindElements(CartItems).Count;
        }

        private By RemoveButton(string productId) =>
            By.CssSelector($"[data-test='remove-{productId}']");

        public void RemoveItem(string productId)
        {
            Waits.UntilClickable(_driver, RemoveButton(productId)).Click();
        }
        public void ClickCheckout()
        {
            Waits.UntilClickable(_driver, CheckoutButton).Click();
        }
    }
}