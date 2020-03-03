using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using WebCov;
using WebCov.Driver;
using Wikipedia.UI.Tests.Elements;

namespace Wikipedia.UI.Tests
{
    public class WikipediaMainPageTests
    {
        private WebDriverContainer _driverContainer;
        private WelcomePage _welcomePage;
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var settings = new WebDriverSettings
            {
                BrowserType = BrowserType.Chrome
            };

            _driverContainer = new WebDriverContainer();
            _driver = _driverContainer.StartSession(settings);

            _welcomePage = Container.Create<WelcomePage>(_driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driverContainer.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _driver.Navigate().GoToUrl("https://ru.wikipedia.org");
        }

        [Test]
        public void NavigateToMainPage_CorrectLangVersion()
        {
            var statusRu = _welcomePage.GetStatus();
            var statusRegexRu = new Regex(@"Сейчас в Википедии ([\d\s]+)+ статьи на русском языке\.");

            statusRu.Should()
                .Match(v => statusRegexRu.IsMatch(v), "russian version should be opened");
        }

        [Test]
        public void NavigateToMainPage_CanSwitchLangVersion()
        {
            _welcomePage.LanguageSelector.SelectLanguage("be");
            var statusBe = _welcomePage.GetStatus();
            var statusRegexBe = new Regex(@"У беларускім раздзеле — ([\d\s]+)+ артыкулы");

            statusBe.Should()
                .Match(v => statusRegexBe.IsMatch(v), "russian version should be changed to belorussian");
        }

        [Test]
        public void NavigateToMainPage_LogoRedirectsToMainPage()
        {
            _driver.Navigate().GoToUrl("https://ru.wikipedia.org/wiki/Википедия:Форум");

            var logoExists = _welcomePage.IsLogoExists();
            logoExists.Should()
                .BeTrue("any wiki page must have logo");

            _welcomePage.ClickOnLogo();
            logoExists = _welcomePage.WaitLogoExists(TimeSpan.FromSeconds(3));
            logoExists.Should()
                .BeTrue("any wiki page must have logo");
        }
    }
}