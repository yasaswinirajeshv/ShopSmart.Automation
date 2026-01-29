using FluentAssertions;
using ShopSmart.Automation.Core;
using ShopSmart.Automation.Pages;
using Xunit;

namespace ShopSmart.Automation.Tests;

public class E2ECheckoutTests : TestBase
{
    [Fact]
    public async Task Login_AddToCart_Checkout_ShouldPass()
    {
        // ✅ Arrange
        var loginPage = new LoginPage(Driver, Settings);

        // ✅ Act
        var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

        // ✅ Assert
        inventoryPage.GetTitle().Should().Be("Products");

        // ✅ Add item
        inventoryPage.AddBackpackToCart();
        inventoryPage.GetCartBadgeCount().Should().Be(1);

        // ✅ Go to cart
        var cartPage = inventoryPage.GoToCart();
        cartPage.IsItemPresent().Should().BeTrue();

        // ✅ Checkout
        var checkoutPage = cartPage.ClickCheckout();
        checkoutPage.FillInformation("Yasaswini", "Rajesh", "411001");
        checkoutPage.Continue();
        checkoutPage.Finish();

        // ✅ Assert success
        checkoutPage.GetSuccessMessage().Should().Be("Thank you for your order!");

        await Task.CompletedTask;
    }

    [Fact]
    public void Login_WithInvalidPassword_ShouldShowError()
    {
        // ✅ Arrange
        var loginPage = new LoginPage(Driver, Settings);

        // ✅ Act
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("wrong_password");
        loginPage.ClickLogin();

        // ✅ Assert
        loginPage.GetErrorMessage()
            .Should()
            .Contain("Username and password do not match");
    }
}
