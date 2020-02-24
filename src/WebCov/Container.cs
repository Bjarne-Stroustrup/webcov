using OpenQA.Selenium;

namespace WebCov
{
    public abstract class Container
    {
        public Container ParentContainer { get; internal set; }

        internal WebElementSearcher WebElementSearcher { get; set; }

        public IWebElement WebElement => WebElementSearcher.FindElement();

        public By Selector => WebElementSearcher.Selector;
    }
}