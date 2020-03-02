using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class XpathAttribute : SelectorAttribute
    {
        private readonly string _path;

        public XpathAttribute(string path)
        {
            _path = path;
        }

        public override By GetSelector()
        {
            return By.XPath(_path);
        }
    }
}