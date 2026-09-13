using OpenQA.Selenium;
using SauceDemoTests.UI.Core;

namespace SauceDemoTests.UI.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;

        private By FirstNameInput => By.Id("first-name");
        private By LastNameInput => By.Id("last-name");
        private By PostalCodeInput => By.Id("postal-code");
        private By ContinueButton => By.Id("continue");

        private By FinishButton => By.Id("finish");
        private By TotalLabel => By.CssSelector(".summary_total_label");

        private By CompleteHeader => By.CssSelector(".complete-header");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillCustomerInfo(string firstName, string lastName, string postalCode)
        {
            Waits.UntilVisible(_driver, FirstNameInput).SendKeys(firstName);
            Waits.UntilVisible(_driver, LastNameInput).SendKeys(lastName);
            Waits.UntilVisible(_driver, PostalCodeInput).SendKeys(postalCode);
        }

        public void ClickContinue()
        {
            Waits.UntilClickable(_driver, ContinueButton).Click();
        }

        public string GetTotalText()
        {
            return Waits.UntilVisible(_driver, TotalLabel).Text;
        }

        public void ClickFinish()
        {
            Waits.UntilClickable(_driver, FinishButton).Click();
        }

        public string GetConfirmationText()
        {
            return Waits.UntilVisible(_driver, CompleteHeader).Text;
        }
    }
}