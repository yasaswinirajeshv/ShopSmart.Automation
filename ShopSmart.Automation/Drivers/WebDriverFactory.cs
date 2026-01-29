using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Drivers;

public static class WebDriverFactory
{
    public static IWebDriver CreateDriver(AppSettings settings)
    {
        return settings.Browser.ToLower() switch
        {
            "chrome" => CreateChromeDriver(),
            _ => CreateChromeDriver()
        };
    }

    private static IWebDriver CreateChromeDriver()
    {
        var options = new ChromeOptions();

        // ✅ Basic stability
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");
        options.AddArgument("--disable-notifications");

        // ✅ Disable Chrome password manager / popups
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        // ✅ Also disable autofill popups
        options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
        options.AddUserProfilePreference("autofill.profile_enabled", false);

        return new ChromeDriver(options);
    }
}
