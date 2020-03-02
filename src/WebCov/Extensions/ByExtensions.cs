using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebCov.Extensions
{
    public static class ByExtensions
    {
        public static By IndexCurrentLevel(this By by, int index)
        {
            return new ByChained(by, By.XPath($"(../*)[{index + 1}]"));
        }
    }
}