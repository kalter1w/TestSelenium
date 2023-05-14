using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Linq.Expressions;
using TestSelenium.Models.Configuration;

namespace TestSelenium.Driver
{

    public  class DriverInitialize
    {
        private static readonly ApplicationConfiguration configuration = ApplicationConfiguration.GetCongiguration();
        public  WebDriver driver;
        public  WebDriver GetDriver() 
        { 
            switch(configuration.Browser) 
            {
                case "EDGE":
                    driver = new EdgeDriver(); break;
                case "CHROME":
                    driver = new ChromeDriver(); break;                  
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configuration.Timeouts.ImplicitWait);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(configuration.Timeouts.PageLoad);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
