using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebCov;
using Wikipedia.UI.Tests.Elements;

namespace Wikipedia.UI.Tests
{
    public class Tests
    {
        private RemoteWebDriver _driver;
        private WikiPage WikiPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            var containerInitializer = new ContainerInitializer();
            WikiPage = containerInitializer.Initialize<WikiPage>(_driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://ru.wikipedia.org");

            Thread.Sleep(1000);
            Console.WriteLine(WikiPage.GetStatus());

            WikiPage.ClickOnLogo();
        }
    }
}