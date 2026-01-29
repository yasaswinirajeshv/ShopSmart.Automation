using OpenQA.Selenium;
using ShopSmart.Automation.Config;
using ShopSmart.Automation.Utilities;

namespace ShopSmart.Automation.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }
    protected AppSettings Settings { get; }
    protected WaitHelper Wait { get; }

    protected BasePage(IWebDriver driver, AppSettings settings)
    {
        Driver = driver;
        Settings = settings;
        Wait = new WaitHelper(driver, settings.ExplicitWaitSeconds);
    }
}
