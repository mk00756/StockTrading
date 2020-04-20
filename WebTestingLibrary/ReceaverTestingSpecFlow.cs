using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace WebTestingLibrary {
    [Binding]
    public class ReceaverTestingSpecFlow {
        private IWebDriver driver;
        public string input;
        [BeforeScenario]
        public void SetUp() {
            driver = new ChromeDriver();
        }
        [Given(@"I am on the home page of the receaver")]
        public void GivenIAmOnTheHomePageOfTheReceaver() {
            //Loads the page
            driver.Navigate().GoToUrl("http://localhost:55236/Home");
        }

        [Given(@"I have entered in a stock to serch for")]
        public void GivenIHaveEnteredInAStockToSerchFor() {
            //gets the serch button
            IWebElement InputBox = driver.FindElement(By.Id("stockName"));
            input = "FTSE 100";
            //Enter text
            InputBox.SendKeys(input);
        }

        [When(@"I click the serch buton")]
        public void WhenIClickTheSerchButon() {
            //Clicks the button
            driver.FindElement(By.Id("serchButton")).Click();
        }

        [Then(@"The text should show the name of the stock I serched for")]
        public void ThenTheTextShouldShowTheNameOfTheStockISerchedFor() {
            //Checks iof it has worked
            IWebElement Output = driver.FindElement(By.Id("SubTitle"));
            Assert.Equal("Showing results for " + input, Output.Text);
        }
        [AfterScenario]
        public void Dispose() {
            driver.Dispose();
        }
    }
}
