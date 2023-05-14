using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestSelenium.Driver;
using TestSelenium.Models.Configuration;
using TestSelenium.PageObjects.GooglePage;

namespace TestSelenium.Tests.SearchTests
{
    public class Tests
    {
        private readonly ApplicationConfiguration _configuration = ApplicationConfiguration.GetCongiguration();
        private IWebDriver _driver;
        private GooglePage googlePage;
        private WebDriverWait wait;


        [SetUp]
        public void SetUp()
        {
            DriverInitialize driverInitialization = new DriverInitialize();
            _driver = driverInitialization.GetDriver();
            googlePage = new GooglePage(_driver);
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void SearchAndAnalyze()
        {
            googlePage.OpenPage(_configuration.Links.Google);
            googlePage.SearchByQuery(_configuration.SearchQuery);
            var results = googlePage.GetSearchItems();
            Assert.AreEqual(true, results[3].Text.Contains(_configuration.StringForCompare));
        }
    }
}