using OpenQA.Selenium;

namespace WebCov.Extensions
{
    public static class WebElementExtensions
    {
        public static TContainer ToContainer<TContainer>(this IWebElement webElement)
            where TContainer : Container
        {
            return Container.Create<TContainer>(webElement);
        }
    }
}