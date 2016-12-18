using NUnit.Framework;


namespace automatic_tests.Tests
{
    [TestFixture]
    class Tests
    {
            private Steps.Steps steps = new Steps.Steps();
            private const string USERNAME = "mishanstvo";
            private const string PASSWORD = "87654321";
            private const string WRONG_PASSWORD = "123456";
            private const string TEXT_TO_SEARCH = "Под покровом ночи / Nocturnal Animals (Том Форд / Tom Ford) [2016 г., триллер, драма, TS] Dub";
            private const string NAVIGATION_LINK = "Кино СССР";
            private const string LANGUARE_CHECK = "Edit profile";
            private const string NEW_PASSWORD = "987654321";
            private const string TEST = "TEST6";
            private const string CHANGE_TEST = "TEST5";
            private const string PASSKEY = "S9fkrH7OZH";
            private const string COMMENT_TEST = "Test comment";
        [SetUp]
            public void Init()
            {
                steps.InitBrowser();
            }

            [TearDown]

            public void Cleanup()
            {
                steps.CloseBrowser();
            }

        [Test]
        public void Login()
        {
            steps.Login(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        }
        [Test]
        public void LogOff()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.LogOff();
            Assert.True(steps.IsLoggedOff());
        }
        [Test]
        public void Search()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.SearchFilm(TEXT_TO_SEARCH);
            Assert.True(steps.IsSearchedFilm(TEXT_TO_SEARCH));
        }
        [Test]
        public void WrongLogin()
        {
            steps.Login(USERNAME, WRONG_PASSWORD);
            Assert.True(steps.IsLoggedOff());
        }
        [Test]
        public void NavigationPanelTest()
        {
            steps.GoThroughPanel(NAVIGATION_LINK);
            Assert.True(steps.IsHistoryPage(NAVIGATION_LINK));
        }
        [Test]
        public void ChangeLanguage()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangeLanguageEnglish();

            Assert.True(steps.IsChangeLanguage());
            steps.ChangeLanguageRussian();
            //  steps.DeleteAvatar();
        }
        [Test]
        public void AddDistr()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.CreateDistr(TEST);
            Assert.True(steps.IsCreateDistr(TEST));
        }
        [Test]
        public void AddAvatar()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            Assert.False(steps.IsDefaultAvatar());
            //    steps.DeleteAvatar();
            //}
        }
        [Test]
        public void DeleteAvatar()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            steps.DeleteAvatar();
            Assert.True(steps.IsDefaultAvatar());

        }
        [Test]
        public void CreateMessage()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.CreateMessage(TEST, USERNAME);

            Assert.True(steps.IsCreateMessage(TEST));
        }
        [Test]
        public void ViewPasskey()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ViewPasskey(USERNAME);

            Assert.True(steps.isViewPasskey(PASSKEY));
        }
        [Test]
        public void ChangeDistr()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangeDistr(TEST, CHANGE_TEST);
            Assert.True(steps.IsCreateDistr(CHANGE_TEST));
        }
        [Test]
        public void AddComment()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.AddComment(CHANGE_TEST, COMMENT_TEST);
            Assert.True(steps.IsAddComment(COMMENT_TEST));
        }
        [Test]
        public void DeleteComment()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.DeleteComment(CHANGE_TEST);
            Assert.False(steps.IsDeleteComment());
        }
        [Test]
        public void ChangePassword()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangePassword(PASSWORD, NEW_PASSWORD);

            steps.LogOff();
            System.Threading.Thread.Sleep(5000);
            steps.Login(USERNAME, NEW_PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        
        }
    }
}