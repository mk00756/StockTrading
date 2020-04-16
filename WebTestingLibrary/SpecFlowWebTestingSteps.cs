using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTestingLibrary {
    [Binding]
    public class SpecFlowWebTestingSteps {

        //Veriables
        IWebDriver driver;
        string url;

        [Before]
        public void SetUp() {
            driver = new ChromeDriver();
            url = "http://localhost:55236/";
        }

        [Given(@"I am on the add page on the sender")]
        public void GivenIAmOnTheAddPageOnTheSender() {
            driver.Navigate().GoToUrl(url + "add");
        }

        [When(@"A stock name is entered in the name box")]
        public void WhenAStockNameIsEnteredInTheNameBox() {
            driver.FindElement(By.Name("stockName")).SendKeys("SpecFlowAdd");
        }

        [When(@"A price is added in the price box")]
        public void WhenAPriceIsAddedInThePriceBox() {
            driver.FindElement(By.Name("stockPrice")).SendKeys("350");
        }

        [When(@"I click the add button")]
        public void WhenIClickTheAddButton() {
            driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button")).Click();
        }

        [Then(@"the stock should apear in the table on the home page")]
        public void ThenTheStockShouldApearInTheTableOnTheHomePage() {
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
                if (text == "SpecFlowAdd") {
                    containsValue = true;
                    break;
                }
            }
            Assert.True(containsValue);
        }

        [After]
        public void TestCompleted() {
            driver.Dispose();
        }

    }
}
