using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace WebTestingLibrary {
    [Binding]
    public class WebTestingSpecFlow {
        private IWebDriver driver;
        public string name = "AddingStockByTest";
        public double price = 350;
        [BeforeScenario]
        public void SetUp() {
            driver = new ChromeDriver();
        }
        [Given(@"I am on the add stock page")]
        public void GivenIAmOnTheAddStockPage() {
            driver.Navigate().GoToUrl("https://localhost:44372/add");
        }
        [Given(@"I have eenter a stock name and a stock price")]
        public void GivenIHaveEenterAStockNameAndAStockPrice() {
            //Adds data to the text box
            driver.FindElement(By.Name("stockName")).SendKeys(name);
            driver.FindElement(By.Name("stockPrice")).SendKeys(price.ToString());
        }
        [When(@"I press the add button")]
        public void WhenIPressTheAddButton() {
            driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();
        }
        [Then(@"the stock shopuld apear in the table on the home page")]
        public void ThenTheStockShopuldApearInTheTableOnTheHomePage() {
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

        [Given(@"I am on the update stock page")]
        public void GivenIAmOnTheUpdateStockPage() {
            //Loads the page
            driver.Navigate().GoToUrl("https://localhost:44372/update");
        }

        [When(@"I press the update button button")]
        public void WhenIPressTheUpdateButtonButton() {
            driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();
        }

        [Then(@"the stock price shuld update on the hopme page")]
        public void ThenTheStockPriceShuldUpdateOnTheHopmePage() {
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
        [Given(@"I am on the delete page")]
        public void GivenIAmOnTheDeletePage() {
            //Loads the page
            driver.Navigate().GoToUrl("https://localhost:44372/delete");
        }
        [Given(@"I have enterd a stock to delet")]
        public void GivenIHaveEnterdAStockToDelet() {
            //Veriables
            string name = "AddingStockByTest";
            //Adds data to the text box
            driver.FindElement(By.Name("stockName")).SendKeys(name);
        }
        [When(@"I click the delete button")]
        public void WhenIClickTheDeleteButton() {
            driver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/button")).Click();
        }
        [Then(@"The strock should have been removed from the table")]
        public void ThenTheStrockShouldHaveBeenRemovedFromTheTable() {
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
        [AfterScenario]
        public void Dispose() {
            driver.Dispose();
        }
    }
}