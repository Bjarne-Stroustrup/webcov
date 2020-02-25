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
            _selector = selectors.Count == 1
                ? selectors.First()
                : new ByChained(selectors.ToArray());
        }

        public By Selector => _selector;

        public ISearchContext Context => _searchContext;

        public IWebElement FindElement()
        {
            return _searchContext.FindElement(_selector);
        }

        public IReadOnlyCollection<IWebElement> FindAllElements()
        {
            return _searchContext.FindElements(_selector);
        }
    }
}