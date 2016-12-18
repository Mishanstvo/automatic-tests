using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "http://torrents.by/forum/profile.php?mode=editprofile";

        [FindsBy(How = How.XPath, Using = "http://torrents.by/forum/profile.php")]
        private IWebElement Profile;

        [FindsBy(How = How.XPath, Using = "//*[@id='avatar-img']/img")]
        private IWebElement imgProfile;

        [FindsBy(How = How.Name, Using = "delete_avatar")]
        private IWebElement checkboxDeletePhoto;
        
       public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public void ProfileClick(string username)
        {
            driver.FindElement(By.LinkText(username)).Click();
            System.Threading.Thread.Sleep(2000);
        }
        public void CreateMessageClick()
        {
            driver.FindElement(By.LinkText("Отправить ЛС")).Click();
            System.Threading.Thread.Sleep(2000);
        }
        public void OpenAllMessages()
        {
            driver.Navigate().GoToUrl("http://torrents.by/forum/privmsg.php?folder=inbox");
        }
        public void ViewPasskey()
        {
            driver.FindElement(By.LinkText("Показать")).Click();
        }
        public void InputMessage(string test)
        {

            driver.FindElement(By.Name("subject")).SendKeys(test);
            driver.FindElement(By.Id("message")).SendKeys(test);

        }
        public void SumbitMessageClick()
        {
            driver.FindElement(By.Id("post-submit-btn")).Click();
        }

        public void ChangeLanguageEnglish()
        {
          new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Name("user_lang"))).SelectByText("English");
          //  driver.FindElement(By.Name("submit")).Click();
        }
        public void ChangeLanguageRussian()
        {
            new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Name("user_lang"))).SelectByText("Русский");
            //  driver.FindElement(By.Name("submit")).Click();
        }
        //public bool isEnglishLanguare()
        //{
        //    IWebElement linkFilm = driver.FindElement(By.LinkText("Edit Profile"));
        //    Console.WriteLine(linkFilm.Text);
        //    return linkFilm.Text;

        //}
        public void LoadPicture()
        {
            IWebElement inputChooseFile = driver.FindElement(By.Name("avatar"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"img/images.jpg"));
            System.Threading.Thread.Sleep(2000);
            

        }
        public void SubmitClick()
        {
            IWebElement buttonSubmit = driver.FindElement(By.Name("submit"));
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public bool isDefaultImg()
        {
            Console.WriteLine(imgProfile.GetAttribute("Src"));
            return imgProfile.GetAttribute("src").Equals("http://torrents.by/forum/data/avatars/gallery/noavatar.png");
        }
        public void SetCheckboxDeletePhoto()
        {
            checkboxDeletePhoto.Click();
        }
        public void EnterNewPasswordInfo(string oldPassword,string newPassword)
        {
            IWebElement inputOldPassword = driver.FindElement(By.Name("cur_pass"));
            inputOldPassword.SendKeys(oldPassword);
            IWebElement inputNewPassword = driver.FindElement(By.Name("new_pass"));
            inputNewPassword.SendKeys(newPassword);
            IWebElement inputRepeat = driver.FindElement(By.Name("cfm_pass"));
            inputRepeat.SendKeys(newPassword);
        }
    }
}
