using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebCov
{
    public partial class Container
    {
        internal WebElementSearcher WebElementSearcher { get; set; }

        public IWebElement WebElement => WebElementSearcher.FindElement();

        public IReadOnlyCollection<IWebElement> WebElements => WebElementSearcher.FindAllElements();
    }
}