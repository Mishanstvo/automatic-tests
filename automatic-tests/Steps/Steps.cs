using System;
using OpenQA.Selenium;

namespace automatic_tests.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void Login(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);

        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetLoggedInUserName());
            return (mainPage.GetLoggedInUserName().Equals(username));
        }
        public void LogOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }
        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }
      
        public bool IsSearchedFilm(string filmName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.GetFindFilm(filmName).Trim().ToLower().Equals(filmName.Trim().ToLower());
        }
        public void SearchFilm(string filmName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(filmName);
        }
      
        public void ChangeLanguageEnglish()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.ChangeLanguageEnglish();
            profilePage.SubmitClick();
            profilePage.OpenPage();

        }
        public void ChangeLanguageRussian()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.ChangeLanguageRussian();
            profilePage.SubmitClick();
            profilePage.OpenPage();

        }
        public bool IsChangeLanguage()
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText("Options"));
            //  Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals("Options");
        }

        public void CreateDistr(string test)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.CreateDistr();
            testForumPage.InputDistr(test);
            testForumPage.ButtonSumbitAll();
            driver.FindElement(By.LinkText("Перейти к сообщению")).Click();

        }
        public void ChangeDistr(string test,string changeTest)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.OpenDistr(test);
            testForumPage.ChangeDistr();
            testForumPage.InputDistr(changeTest);
            testForumPage.ButtonSumbitAll();

        }
        public void AddComment(string changeTest, string testComment)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.OpenDistr(changeTest);
            testForumPage.InputComment(testComment);
            testForumPage.ButtonSumbit();
            System.Threading.Thread.Sleep(3000);
       
        }
      

        public bool IsAddComment(string testComment)
        {
            IWebElement pageHeader = driver.FindElement(By.XPath("//div[@class='post_body']//span[. = 'Test comment' ]"));
          //  Console.WriteLine(pageHeader.Text);
            return (pageHeader.Text.Equals(testComment));
        }
        public void DeleteComment(string changeTest)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.OpenDistr(changeTest);
            testForumPage.DeleteComment();
          //  testForumPage.ButtonSumbit();
            System.Threading.Thread.Sleep(3000);
}
        public bool IsDeleteComment()
        {
            IWebElement pageHeader =  driver.FindElement(By.CssSelector("img[alt=\"[x]\"]"));
            //  Console.WriteLine(pageHeader.Text);
            //  return pageHeader.Text;
            
            return pageHeader.Displayed;
        }


        public bool IsCreateDistr(string test)
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText(test));
            //  Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals(test);
        }


        public void GoThroughPanel(string filmType)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoThroughPanel(filmType);
        }
        public bool IsHistoryPage(string filmType)
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText(filmType));
          //  Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals(filmType);
        }
       
      
        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
           // profilePage.EditProfileClick();
            profilePage.LoadPicture();
            profilePage.SubmitClick();
            driver.FindElement(By.LinkText("Перейти к просмотру профиля")).Click();

        }
        public bool IsDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }
        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
         
            profilePage.SetCheckboxDeletePhoto();
            profilePage.SubmitClick();
            driver.FindElement(By.LinkText("Перейти к просмотру профиля")).Click();
        }
        public void CreateMessage(string test, string username)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.ProfileClick(username);
            profilePage.CreateMessageClick();
            profilePage.InputMessage(test);
            profilePage.SumbitMessageClick();
            profilePage.ProfileClick(username);
            profilePage.OpenAllMessages();
            System.Threading.Thread.Sleep(5000);
            //    driver.FindElement(By.LinkText("Перейти к просмотру профиля")).Click();
        }
        public void ViewPasskey(string username)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.ProfileClick(username);
            profilePage.ViewPasskey();
     
            System.Threading.Thread.Sleep(5000);
            //    driver.FindElement(By.LinkText("Перейти к просмотру профиля")).Click();
        }
        public bool isViewPasskey(string passkey)
        {
            IWebElement pageHeader = driver.FindElement(By.Id("passkey"));
            Console.WriteLine(pageHeader.Text);
          //  return pageHeader.Text;
            return (pageHeader.Text.Equals(passkey));
        }
        public bool IsCreateMessage(string test)
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText(test));
            //  Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals(test);
        }
      
        public bool IsRegistryPage()
        {
            return driver.Title.Equals("Регистрация посетителя");
        }
        public void ChangePassword(string oldPassword,string newPassword)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();

           // profilePage.EditProfileClick();
            profilePage.EnterNewPasswordInfo(oldPassword, newPassword);
            profilePage.SubmitClick();
            mainPage.OpenPage();
        }
    }
}
