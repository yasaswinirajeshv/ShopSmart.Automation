using OpenQA.Selenium;
using ShopSmart.Automation.Config;

namespace ShopSmart.Automation.Pages;

public class CartPage : BasePage
{
    private readonly By _checkoutButton = By.Id("checkout");
    private readonly By _cartItem = By.ClassName("cart_item");
    private readonly By _cartItemName = By.ClassName("inventory_item_name");

    public CartPage(IWebDriver driver, AppSettings settings) : base(driver, settings) { }

    public bool IsItemPresent()
    {
        try
        {
            Wait.WaitForVisible(_cartItem);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetFirstCartItemName()
    {
        return Wait.WaitForVisible(_cartItemName).Text;
    }

    public CheckoutPage ClickCheckout()
    {
        Wait.WaitForClickable(_checkoutButton).Click();
        return new CheckoutPage(Driver, Settings);
    }
}
