using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class CssAttribute : SelectorAttribute
    {
        private readonly string _path;

        public CssAttribute(string path)
        {
            _path = path;
        }

        public override By GetSelector()
        {
            return By.XPath(_path);
        }
    }
}