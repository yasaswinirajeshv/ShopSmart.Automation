using OpenQA.Selenium;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Pages;

public class MenuPage : BasePage
{
    private readonly By _menuButton = By.Id("react-burger-menu-btn");
    private readonly By _logoutLink = By.Id("logout_sidebar_link");

    public MenuPage(IWebDriver driver, AppSettings settings) : base(driver, settings) { }

    public void OpenMenu()
    {
        Wait.WaitForClickable(_menuButton).Click();

        // ✅ Wait until logout becomes visible (menu opened)
        Wait.WaitForVisible(_logoutLink);
    }

    public LoginPage Logout()
    {
        OpenMenu();
        Wait.WaitForClickable(_logoutLink).Click();
        return new LoginPage(Driver, Settings);
    }
}
