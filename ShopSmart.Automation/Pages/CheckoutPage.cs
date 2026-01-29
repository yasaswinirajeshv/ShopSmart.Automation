using OpenQA.Selenium;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Pages;

public class CheckoutPage : BasePage
{
    private readonly By _checkoutTitle = By.CssSelector(".title");

    private readonly By _firstName = By.Id("first-name");
    private readonly By _lastName = By.Id("last-name");
    private readonly By _postalCode = By.Id("postal-code");
    private readonly By _continueButton = By.Id("continue");
    private readonly By _finishButton = By.Id("finish");
    private readonly By _successMessage = By.ClassName("complete-header");
    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    public CheckoutPage(IWebDriver driver, AppSettings settings) : base(driver, settings) { }

    public string GetCheckoutTitle()
    {
        return Wait.WaitForVisible(_checkoutTitle).Text;
    }

    public void FillInformation(string firstName, string lastName, string postalCode)
    {
        Wait.WaitForVisible(_firstName).Clear();
        Wait.WaitForVisible(_firstName).SendKeys(firstName);

        Wait.WaitForVisible(_lastName).Clear();
        Wait.WaitForVisible(_lastName).SendKeys(lastName);

        Wait.WaitForVisible(_postalCode).Clear();
        Wait.WaitForVisible(_postalCode).SendKeys(postalCode);
    }

    public void Continue()
    {
        Wait.WaitForClickable(_continueButton).Click();
    }

    public void Finish()
    {
        Wait.WaitForClickable(_finishButton).Click();
    }

    public string GetSuccessMessage()
    {
        return Wait.WaitForVisible(_successMessage).Text;
    }

    public string GetErrorMessage()
    {
        return Wait.WaitForVisible(_errorMessage).Text;
    }
}
