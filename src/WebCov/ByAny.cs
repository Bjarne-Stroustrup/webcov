using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace WebCov
{
    public class ByAny : By
    {
        private readonly By[] _bys;

        public ByAny(params By[] bys)
        {
            _bys = bys;
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            var elements = FindElements(context);
            if (elements.Count <= 0)
            {
                throw new NoSuchElementException("Cannot locate an element using " + this);
            };

            return elements[0];
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var elements = _bys
                .SelectMany(context.FindElements)
                .ToList();

            return new ReadOnlyCollection<IWebElement>(elements);
        }

        public override string ToString()
        {
            var bys = string.Join(", ", _bys.Select(b => b.ToString()));
            return $"By.Any([{bys}])";
        }
    }
}