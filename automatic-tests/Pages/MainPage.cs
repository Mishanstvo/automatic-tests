using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace automatic_tests.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://torrents.by/forum/index.php";
        private bool acceptNextAlert = true;


        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Name, Using = "login_username")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Name, Using = "login_password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.CssSelector, Using = "#test > form:nth-child(1) > button:nth-child(5)")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.ClassName, Using = "colorUser")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.Id, Using = "search-text")]
        private IWebElement inputSearch;

        [FindsBy(How = How.CssSelector, Using = "input.med")]
        private IWebElement buttonStartSearch;

        IWebElement linkFilm;

        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }



        public void Login(string username, string password)
        {
          //  buttonEnter.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonEnter.Click();
            //buttonSubmit.Click();            
            System.Threading.Thread.Sleep(1000);
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public void LogOff()
        {
            IWebElement buttonExit = driver.FindElement(By.LinkText("Выход"));
            buttonExit.Click();
            Thread.Sleep(2000);
            Regex.IsMatch(CloseAlertAndGetItsText(), "^Вы уверены, что хотите выйти[\\s\\S]$");
         
        }
        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }
      
        public bool isEnterButtonExists()
        {
            return buttonEnter.Displayed;
        }
        public void GoThroughPanel(string filmType)
        {
            driver.FindElement(By.LinkText("Наше кино")).Click();
            Thread.Sleep(2000);
            IWebElement linkPanel = driver.FindElement(By.LinkText(filmType));
            linkPanel.Click();
            Console.WriteLine(linkPanel.Text);
            Thread.Sleep(5000);
        }
        public void Search(string text)
        {
            inputSearch.SendKeys(text);
            buttonStartSearch.Click();
        }

        public string GetFindFilm(string film_name)
        {
            linkFilm = driver.FindElement(By.LinkText(film_name));
            Console.WriteLine(linkFilm.Text);
            return linkFilm.Text;
        }
    }
}
