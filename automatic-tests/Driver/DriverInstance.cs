using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;


namespace automatic_tests.Driver
{
    static class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
