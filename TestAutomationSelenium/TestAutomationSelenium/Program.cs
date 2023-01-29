using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.google.com/");

            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Javatpoint tutorials");

            IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            searchButton.Click();

            System.Threading.Thread.Sleep(3000);

            driver.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
