using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[TestClass]


public class LoginTests
{
    private IWebDriver driver;

    [TestInitialize]
    public void TestSetup()
    {
        driver = new ChromeDriver();
    }

    [TestMethod]
    public void LoginSuccessful()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        IWebElement username = driver.FindElement(By.Id("user-name"));
        username.SendKeys("standard_user");
        IWebElement password = driver.FindElement(By.Id("password"));
        password.SendKeys("secret_sauce");
        password.Submit();

        Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
    }

    [TestMethod]
    public void LoginFailedWrongUsername()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        IWebElement username = driver.FindElement(By.Id("user-name"));
        username.SendKeys("wrong_user");
        IWebElement password = driver.FindElement(By.Id("password"));
        password.SendKeys("secret_sauce");
        password.Submit();

        IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-button"));
        Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage.Text);
    }

    [TestMethod]
    public void LoginFailedWrongPassword()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        IWebElement username = driver.FindElement(By.Id("user-name"));
        username.SendKeys("standard_user");
        IWebElement password = driver.FindElement(By.Id("password"));
        password.SendKeys("wrong_password");
        password.Submit();

        IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-button"));
        Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage.Text);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        driver.Quit();
    }
}
