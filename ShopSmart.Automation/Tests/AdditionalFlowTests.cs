using FluentAssertions;
using ShopSmart.Automation.Core;
using ShopSmart.Automation.Pages;
using Xunit;

namespace ShopSmart.Automation.Tests;

public class AdditionalFlowTests : TestBase
{
    [Fact]
    public void Login_WithLockedOutUser_ShouldShowLockedMessage()
    {
        // ✅ Arrange
        var loginPage = new LoginPage(Driver, Settings);

        // ✅ Act
        loginPage.EnterUsername("locked_out_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        // ✅ Assert
        loginPage.GetErrorMessage()
            .Should()
            .Contain("locked out");
    }

    [Fact]
    public void Checkout_WithoutFirstName_ShouldShowError()
    {
        // ✅ Arrange
        var loginPage = new LoginPage(Driver, Settings);

        // ✅ Login
        var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
        inventoryPage.GetTitle().Should().Be("Products");

        // ✅ Add item
        inventoryPage.AddBackpackToCart();
        inventoryPage.GetCartBadgeCount().Should().Be(1);

        // ✅ Go to cart
        var cartPage = inventoryPage.GoToCart();
        cartPage.IsItemPresent().Should().BeTrue();

        // ✅ Checkout
        var checkoutPage = cartPage.ClickCheckout();
        checkoutPage.GetCheckoutTitle().Should().Contain("Checkout");

        // ❌ Missing first name
        checkoutPage.FillInformation("", "Rajesh", "411001");
        checkoutPage.Continue();

        // ✅ Assert error message
        checkoutPage.GetErrorMessage()
            .Should()
            .Contain("First Name is required");
    }

    [Fact]
    public void Login_ThenLogout_ShouldReturnToLoginPage()
    {
        // ✅ Arrange
        var loginPage = new LoginPage(Driver, Settings);

        // ✅ Login
        var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
        inventoryPage.GetTitle().Should().Be("Products");

        // ✅ Logout
        var menuPage = new MenuPage(Driver, Settings);
        menuPage.Logout();

        // ✅ Assert back on login
        Driver.Url.Should().Contain("saucedemo.com");
        Driver.Url.Should().NotContain("inventory");
    }
}
