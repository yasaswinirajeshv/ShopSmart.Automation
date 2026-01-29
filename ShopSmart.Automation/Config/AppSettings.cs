namespace ShopSmart.Automation.Config;

public class AppSettings
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Browser { get; set; } = "Chrome";
    public int ImplicitWaitSeconds { get; set; } = 0;
    public int ExplicitWaitSeconds { get; set; } = 10;
}
