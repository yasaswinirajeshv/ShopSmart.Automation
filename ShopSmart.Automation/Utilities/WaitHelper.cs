using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ShopSmart.Automation.Utilities;

public class WaitHelper
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public WaitHelper(IWebDriver driver, int seconds)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
    }

    public IWebElement WaitForVisible(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitForClickable(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}
    