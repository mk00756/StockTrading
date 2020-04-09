using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTestingLibrary {
    public class StockTraderReceiverWebTest {

        [Fact]
        public void OpenReceaverPage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("http://localhost:55236/Home");
                //Checks if it is right
                Assert.Equal("Stock Trader Receiver - Home", driver.Title);
                Assert.Equal("http://localhost:55236/Home", driver.Url);
            }
        }

        [Fact]
        public void ReloadReceaverHomePage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("http://localhost:55236/Home");
                //refreshes the page
                driver.Navigate().Refresh();
                //Checks if it is right
                Assert.Equal("Stock Trader Receiver - Home", driver.Title);
                Assert.Equal("http://localhost:55236/Home", driver.Url);
            }
        }

        [Fact]
        public void ClickSerchButton() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("http://localhost:55236/Home");
                //gets the serch button
                IWebElement SerchButton = driver.FindElement(By.Id("serchButton"));
                IWebElement InputBox = driver.FindElement(By.Id("stockName"));
                IWebElement Output = driver.FindElement(By.Id("SubTitle"));
                string input = "FTSE 100";
                //Enter text
                InputBox.SendKeys(input);
                //Clicks the button
                SerchButton.Click();
                //Checks iof it has worked
                Assert.Equal("Showing results for " + input, Output.Text);

            }
        }
    }
}
