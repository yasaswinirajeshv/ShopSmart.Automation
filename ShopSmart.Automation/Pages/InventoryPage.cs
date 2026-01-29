using OpenQA.Selenium;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Pages;

public class InventoryPage : BasePage
{
    private readonly By _pageTitle = By.CssSelector(".title");
    private readonly By _addBackpack = By.Id("add-to-cart-sauce-labs-backpack");
    private readonly By _cartIcon = By.ClassName("shopping_cart_link");
    private readonly By _cartBadge = By.ClassName("shopping_cart_badge");

    public InventoryPage(IWebDriver driver, AppSettings settings) : base(driver, settings) { }

    public string GetTitle()
    {
        return Wait.WaitForVisible(_pageTitle).Text;
    }

    public void AddBackpackToCart()
    {
        Wait.WaitForClickable(_addBackpack).Click();
    }

    public int GetCartBadgeCount()
    {
        var badges = Driver.FindElements(_cartBadge);
        if (badges.Count == 0)
            return 0;

        return int.Parse(badges[0].Text);
    }

    public CartPage GoToCart()
    {
        Wait.WaitForClickable(_cartIcon).Click();
        return new CartPage(Driver, Settings);
    }
}
