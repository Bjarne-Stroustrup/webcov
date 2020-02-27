using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebCov
{
    public static class ByExtensions
    {
        public static By Nth(this By by, int index)
        {
            return new ByChained(by, By.XPath($"(../*)[{index + 1}]"));
        }
    }
}