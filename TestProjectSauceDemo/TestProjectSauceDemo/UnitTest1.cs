using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Selenium.Examples
{
    [TestClass]
    public class LogInTest
    {
        

        [TestMethod]
        public void ProductsDisplayedTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var usernameTextbox = driver.FindElement(By.Id("user-name"));
            var passwordTextbox = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.ClassName("btn_action"));

            usernameTextbox.SendKeys("standard_user");
            passwordTextbox.SendKeys("secret_sauce");
            loginButton.Click();

            var products = driver.FindElements(By.ClassName("inventory_item"));

            Assert.IsTrue(products.Count > 0);

            driver.Quit();
        }
        [TestMethod]
        public void LoginWithEmptyUsernameAndPasswordTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var usernameTextbox = driver.FindElement(By.Id("user-name"));
            var passwordTextbox = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.ClassName("btn_action"));

            loginButton.Click();

            var errorMessage = driver.FindElement(By.XPath("//h3[text()='Username is required']")).Displayed;

            Assert.IsTrue(errorMessage);

            driver.Quit();
        }

        [TestMethod]
        public void LoginWithInvalidCredentialsTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var usernameTextbox = driver.FindElement(By.Id("user-name"));
            var passwordTextbox = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.ClassName("btn_action"));

            usernameTextbox.SendKeys("invalid_user");
            passwordTextbox.SendKeys("invalid_password");
            loginButton.Click();

            var errorMessage = driver.FindElement(By.XPath("//h3[text()='Epic sadface: Username and password do not match any user in this service']")).Displayed;

            Assert.IsTrue(errorMessage);

            driver.Quit();
        }
    }
}

