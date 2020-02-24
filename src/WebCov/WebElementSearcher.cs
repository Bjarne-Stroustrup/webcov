using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebCov
{
    internal class WebElementSearcher
    {
        private readonly ISearchContext _searchContext;
        private readonly By _selector;

        public WebElementSearcher(ISearchContext searchContext,  ICollection<By> selectors)
        {
            _searchContext = searchContext;
            _selector = new ByAll(selectors.ToArray());
        }

        public By Selector => _selector;

        public IWebElement FindElement()
        {
            return _searchContext.FindElement(_selector);
        }
    }
}