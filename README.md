#  ShopSmart Automation Framework (Selenium + C# + xUnit)

An **End-to-End (E2E) Test Automation Framework** built using **C#**, **.NET**, **Selenium WebDriver**, and **xUnit** to automate and validate user flows on a demo e-commerce web application.

This framework is designed using **industry best practices**:
✅ Page Object Model (POM)  
✅ Dependency Injection (DI)  
✅ Configuration Management using `appsettings.json`  
✅ Explicit Waits for stable execution  
✅ FluentAssertions for readable assertions  
✅ AAA Pattern (Arrange–Act–Assert)  
✅ Git & GitHub Version Control

---

## Application Under Test (AUT)

🔗 https://www.saucedemo.com/

SauceDemo is a public demo e-commerce web application used for practicing real-world automation testing.

---

##  Tech Stack Used

- **Language:** C#
- **Framework:** .NET (Compatible with .NET 8 / .NET 10)
- **Automation Tool:** Selenium WebDriver
- **Test Framework:** xUnit
- **Assertion Library:** FluentAssertions
- **Design Pattern:** Page Object Model (POM)
- **Dependency Injection:** Microsoft.Extensions.DependencyInjection
- **Configuration:** Microsoft.Extensions.Configuration + JSON
- **Version Control:** Git + GitHub

---

##  Key Features Implemented

✅ Automated E2E test automation framework  
✅ Stable execution using Explicit Waits  
✅ Maintainable Page Object Model structure  
✅ Config-driven setup using `appsettings.json`  
✅ Clean and readable FluentAssertions  
✅ AAA-based test method structure  
✅ Positive + Negative + Validation scenarios  
✅ Ready to scale with reporting & CI/CD

---

##  Test Scenarios Automated (6 Tests)

### ✅ Positive E2E Flow
1. **Login → Add Product to Cart → Checkout → Order Confirmation**

### ✅ Login Negative Tests
2. **Login with Invalid Password → Error Message Validation**
3. **Login with Locked Out User → Error Message Validation**

### ✅ Checkout Validation Test
4. **Checkout without First Name → Validation Error**

### ✅ Session Flow Test
5. **Login → Logout → Verify User Returned to Login Page**

### ✅ Cart Validation
6. **Cart badge and cart item presence verification**

---

---

## ⚙️ Configuration (appsettings.json)

All environment configuration is controlled using:

 `appsettings.json`

Example:

{
  "AppSettings": {
    "BaseUrl": "https://www.saucedemo.com/",
    "Browser": "Chrome",
    "ImplicitWaitSeconds": 0,
    "ExplicitWaitSeconds": 10
  }
}

---

##  Framework Design (Concepts Used)

###  Page Object Model (POM)
Each page in the application is represented by a separate class containing:
- Page element locators
- Page actions (methods)
- Reusable automation code

This helps achieve:
✅ High maintainability  
✅ Clean separation of concerns  
✅ Reusability across tests

---

### Dependency Injection (DI)
The framework uses Dependency Injection to manage:
- WebDriver instance
- App settings/configuration

This improves:
✅ Scalability  
✅ Clean architecture  
✅ Easier future integration (reports, logging, parallel tests)

---

###  Explicit Wait Mechanism
The framework uses WebDriverWait through a helper utility to ensure:
✅ Elements are visible before interacting  
✅ Elements are clickable before actions  
✅ Reduced flakiness

---

###  AAA Pattern (Arrange – Act – Assert)
All tests follow the AAA structure:

- **Arrange:** Setup required objects and inputs
- **Act:** Perform the automation steps
- **Assert:** Verify expected results

Example:

// Arrange
var loginPage = new LoginPage(Driver, Settings);

// Act
var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

// Assert
inventoryPage.GetTitle().Should().Be("Products");

---

##  How to Run the Tests

### ✅ Run using Visual Studio
1. Open the solution in **Visual Studio**
2. Go to **Test → Test Explorer**
3. Click ✅ **Run All Tests**

### ✅ Run using Command Line
Open terminal inside the project folder and run:

dotnet test

---

##  Troubleshooting

### ✅ Chrome Password Popup Issue
Sometimes Chrome shows password-security popups which can interrupt automation execution.

✅ The framework disables Chrome password manager using ChromeOptions in `WebDriverFactory.cs` to ensure smooth automation runs.

---


.
