using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using ShopSmart.Automation.Config;
using ShopSmart.Automation.Drivers;

namespace ShopSmart.Automation.Core;

public abstract class TestBase : IDisposable
{
    protected IServiceProvider Services { get; private set; }
    protected IWebDriver Driver { get; private set; }
    protected AppSettings Settings { get; private set; }

    protected TestBase()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Settings = config.GetSection("AppSettings").Get<AppSettings>()
                   ?? throw new Exception("Failed to read AppSettings from appsettings.json");

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton(Settings);
        serviceCollection.AddSingleton<IWebDriver>(sp => WebDriverFactory.CreateDriver(Settings));

        Services = serviceCollection.BuildServiceProvider();

        Driver = Services.GetRequiredService<IWebDriver>();
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(Settings.BaseUrl);
    }

    public void Dispose()
    {
        try
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
        catch
        {
            // ignore cleanup exceptions
        }
    }
}
