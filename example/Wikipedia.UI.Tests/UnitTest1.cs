using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebCov;
using WebCov.Driver;
using Wikipedia.UI.Tests.Elements;

namespace Wikipedia.UI.Tests
{
    public class Tests
    {
        private WebDriverContainer _driverContainer;
        private WelcomePage _welcomePage;
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var settings = new WebDriverSettings
            {
                BrowserType = BrowserType.Chrome
            };
            _driverContainer = new WebDriverContainer();
            _driver = _driverContainer.Create(settings);
            var containerInitializer = new ContainerInitializer();

            _welcomePage = containerInitializer.Create<WelcomePage>(_driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driverContainer.Dispose();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://ru.wikipedia.org");

            Thread.Sleep(1000);
            Console.WriteLine(_welcomePage.GetStatus());

            var langCodes = _welcomePage.LanguageSelector.GetAvailableLangCodes();

            Console.WriteLine(string.Join(", ", langCodes));

            _welcomePage.LanguageSelector.SelectLanguage("de");

            _welcomePage.ClickOnLogo();
        }
    }
}