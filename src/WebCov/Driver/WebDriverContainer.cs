using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebCov.Driver
{
    public class WebDriverContainer : IDisposable
    {
        private IWebDriver _driver;

        public IWebDriver Create(WebDriverSettings settings)
        {
            if (_driver != null)
            {
                throw new InvalidOperationException("WebDriver instance was already created");
            }

            return _driver = InitDriver(settings);
        }

        private IWebDriver InitDriver(WebDriverSettings settings)
        {
            switch (settings.DriverType)
            {
                case DriverType.Local:
                    return InitLocalDriver(settings);
                case DriverType.Remote:
                default:
                    throw new InvalidOperationException($"Unsupported Driver Type: {settings.DriverType}");
            }
        }

        private IWebDriver InitLocalDriver(WebDriverSettings settings)
        {
            switch (settings.BrowserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                default:
                    throw new InvalidOperationException($"Unsupported Browser Type: {settings.BrowserType}");
            }
        }

        public void Dispose()
        {
            if (_driver == null)
            {
                return;
            }

            _driver.Quit();
            _driver = null;
        }
    }
}