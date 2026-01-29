using OpenQA.Selenium;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Pages;

public class LoginPage : BasePage
{
    private readonly By _username = By.Id("user-name");
    private readonly By _password = By.Id("password");
    private readonly By _loginButton = By.Id("login-button");
    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    public LoginPage(IWebDriver driver, AppSettings settings) : base(driver, settings) { }

    public void EnterUsername(string username)
    {
        var el = Wait.WaitForVisible(_username);
        el.Clear();
        el.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        var el = Wait.WaitForVisible(_password);
        el.Clear();
        el.SendKeys(password);
    }

    public void ClickLogin()
    {
        Wait.WaitForClickable(_loginButton).Click();
    }

    public InventoryPage LoginAs(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
        return new InventoryPage(Driver, Settings);
    }

    public string GetErrorMessage()
    {
        return Wait.WaitForVisible(_errorMessage).Text;
    }
}
