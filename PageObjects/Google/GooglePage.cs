using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestSelenium.PageObjects.GooglePage
{
    public class GooglePage
    {
        
        private readonly IWebDriver _driver;
        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement searchButton => _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[8]/center/input[1]"));
        private IWebElement searchField => _driver.FindElement(By.XPath("//*[@id=\"APjFqb\"]"));
        private By resultElement => By.ClassName("MjjYud");
        
        public void SearchByQuery(string query)
        {
            searchField.SendKeys(query);
            searchButton.Click();
        }
        public void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public List<IWebElement> GetSearchItems() => _driver.FindElements(resultElement).ToList();

    }
}
