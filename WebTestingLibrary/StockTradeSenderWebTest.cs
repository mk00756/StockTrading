using System;
using Xunit;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTestingLibrary {
    public class StockTradeSenderWebTest {
        [Fact]
        public void OpenSenderHomePage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                //Checks if it is right
                Assert.Equal("https://localhost:44372/", driver.Url);
            }
        }

        [Fact]
        public void OpenSenderCreatePage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/add");
                //Checks if it is right
                Assert.Equal("https://localhost:44372/add", driver.Url);
            }
        }

        [Fact]
        public void OpenSenderEdditPage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/update");
                //Checks if it is right
                Assert.Equal("https://localhost:44372/update", driver.Url);
            }
        }

        [Fact]
        public void OpenSenderDeletePage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/delete");
                //Checks if it is right
                Assert.Equal("https://localhost:44372/delete", driver.Url);
            }
        }

        [Fact]
        public void AddAStock() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/add");
                //Veriables
                string name = "TestStock";
                double price = 350;
                //Adds data to the text box#
                driver.FindElement(By.Name("stockName")).SendKeys(name);
                driver.FindElement(By.Name("stockPrice")).SendKeys(price.ToString());
                driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();

            }
        }

        [Fact]
        public void CheckStockEgsist() {
            using(IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                Assert.Equal("https://localhost:44372/", driver.Url);
            }
        }

    }
}
