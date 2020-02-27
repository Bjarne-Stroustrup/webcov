using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebCov
{
    public class Container
    {
        internal WebElementSearcher WebElementSearcher { get; set; }

        public IWebElement WebElement => WebElementSearcher.FindElement();

        public IReadOnlyCollection<IWebElement> WebElements => WebElementSearcher.FindAllElements();
    }
}