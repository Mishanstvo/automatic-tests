using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;
namespace automatic_tests.Pages
{
    public class TestForumPage : AbstractPage
    {
        private const string BASE_URL = "http://torrents.by/forum/viewforum.php?f=60";


        [FindsBy(How = How.XPath, Using = "(//img[@alt='Создать раздачу'])[2]")]
        private IWebElement createDistr;
       

        [FindsBy(How = How.XPath, Using = "(//div[@class='post_body']//span[. = 'asdasd' ]")]
        private IWebElement SearchComment;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement message;
        [FindsBy(How = How.Name, Using = "subject")]
        private IWebElement inputName;
       
        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement inputMessage;
        [FindsBy(How = How.Id, Using = "post-submit-btn")]
        private IWebElement buttonSumbit;

        IWebElement linkFilm;
        private bool acceptNextAlert = true;
        public TestForumPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);          
        }

        public void CreateDistr()
        {
            createDistr.Click();
           
        }
        public void OpenDistr(string test)
        {
            driver.FindElement(By.LinkText(test)).Click();

        }
        public void ChangeDistr()
        {
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("img[alt=\"[Изменить]\"]")).Click();
            
        }
        public void InputDistr(string test)
        {
            inputName.Clear();
            inputMessage.Clear();
            inputName.SendKeys(test);
            inputMessage.SendKeys(test);
          
        }
        public void InputComment(string testComment)
        {
           
            message.SendKeys(testComment);
            
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
        public void DeleteComment()
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("img[alt=\"[x]\"]")).Click();
            System.Threading.Thread.Sleep(1000);
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Вы уверены, что хотите удалить это сообщение[\\s\\S]$"));
            
        }
        public void ButtonSumbit()
        {
            buttonSumbit.Click();
           
        }
        public void ButtonSumbitAll()
        {
            buttonSumbit.Click();
            driver.FindElement(By.LinkText("Перейти к сообщению")).Click();

        }
        public string GetFindFilm(string film_name)
        {
            linkFilm = driver.FindElement(By.LinkText(film_name));
            Console.WriteLine(linkFilm.Text);
            return linkFilm.Text;
        }
    }
}
