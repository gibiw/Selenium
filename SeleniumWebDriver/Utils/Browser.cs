using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Utils
{
    public static class Browser
    {
        private const string FolderChromeDriver = @"C:\chromedriver";
        private static IWebDriver _webDriver;

        public static void Initialize()
        {
            var options = GetChromeDefaultOptions();
            _webDriver = new ChromeDriver(FolderChromeDriver, options);
        }

        public static void Shutdown()
        {
            _webDriver.Quit();
        }
        
        public static void OpenUrl(string url)
        {
            _webDriver.Url = url;
        }
        
        public static string GetCurrentUrl()
        {
            return _webDriver.Url;
        }

        public static void Click(string selector)
        {
            var element = GetElement(selector);
            
            element.Click();
        }

        public static ICollection<IWebElement> GetElements(string selector)
        {
            return _webDriver.FindElements(By.XPath(selector));
        }
        
        private static IWebElement GetElement(string selector)
        {
            return _webDriver.FindElement(By.XPath(selector));
        }
        
        private static ChromeOptions GetChromeDefaultOptions()
        {
            var defaultOptions = new ChromeOptions();
            defaultOptions.AddArguments(
                "--no-sandbox",
                "--disable-extensions",
                "--test-type",
                "--silent",
                "--disable-gpu",
                "--start-fullscreen",
                "--disable-infobars",
                "--disable-logging",
                "--enable-precise-memory-info",
                "--disable-popup-blocking",
                "--ignore-certificate-errors");

            defaultOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            defaultOptions.AddUserProfilePreference("credentials_enable_service", false);

            return defaultOptions;
        }
    }
}