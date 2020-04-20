using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebTestingLibrary {
    public class StockTradeSenderWebTest {
        [Fact]
        public void OpenSenderHomePage() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                //Checks if it is rightdri
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
                string name = "AddingStockByTest";
                double price = 350;
                //Adds data to the text box
                driver.FindElement(By.Name("stockName")).SendKeys(name);
                driver.FindElement(By.Name("stockPrice")).SendKeys(price.ToString());
                driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                driver.Manage().Window.Maximize();
                //Checs if the value egsists
                bool containsValue = false;
                //Table veriable
                IWebElement table;
                //Gets the table
                table = driver.FindElement(By.XPath("/html/body/div/div/div/div/table"));
                //Finds all of the cells
                var allCells = table.FindElements(By.TagName("td"));
                //Loops through them
                foreach (var cell in allCells) {
                    //Checks if the value is in the cell
                    string text = cell.Text;
                    if (text == name) {
                        containsValue = true;
                        break;
                    }
                }
                Assert.True(containsValue);
            }
        }

        [Fact]
        public void UpdateStock() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/update");
                //Veriables
                string name = "AddingStockByTest";
                double price = 850;
                //Adds data to the text box
                driver.FindElement(By.Name("stockName")).SendKeys(name);
                driver.FindElement(By.Name("stockPrice")).SendKeys(price.ToString());
                driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                driver.Manage().Window.Maximize();
                //Checs if the value egsists
                bool containsValue = false;
                //Table veriable
                IWebElement table;
                //Gets the table
                table = driver.FindElement(By.XPath("/html/body/div/div/div/div/table"));
                //Finds all of the cells
                var allCells = table.FindElements(By.TagName("td"));
                //Loops through them
                for (int i = 0; i < allCells.Count - 1; i++) {
                    //Checks if the value is in the cell
                    string stockName = allCells[i].Text;
                    string stockPrice = allCells[i + 1].Text;
                    if (stockName == name && stockPrice == price.ToString()) {
                        containsValue = true;
                        break;
                    }
                }
                Assert.True(containsValue);
            }
        }

        [Fact]
        public void RemoveStock() {
            using (IWebDriver driver = new ChromeDriver()) {
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/delete");
                //Veriables
                string name = "AddingStockByTest";
                //Adds data to the text box
                driver.FindElement(By.Name("stockName")).SendKeys(name);
                driver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/button")).Click();
                //Loads the page
                driver.Navigate().GoToUrl("https://localhost:44372/");
                driver.Manage().Window.Maximize();
                //Checs if the value egsists
                bool containsValue = false;
                //Table veriable
                IWebElement table;
                //Gets the table
                table = driver.FindElement(By.XPath("/html/body/div/div/div/div/table"));
                //Finds all of the cells
                var allCells = table.FindElements(By.TagName("td"));
                //Loops through them
                foreach (var cell in allCells) {
                    //Checks if the value is in the cell
                    string text = cell.Text;
                    if (text == name) {
                        containsValue = true;
                        break;
                    }
                }
                Assert.False(containsValue);
            }
        }
    }
}