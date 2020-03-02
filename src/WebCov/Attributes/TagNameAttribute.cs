using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class TagNameAttribute : SelectorAttribute
    {
        private readonly string _tagName;

        public TagNameAttribute(string tagName)
        {
            _tagName = tagName;
        }

        public override By GetSelector()
        {
            return By.TagName(_tagName);
        }
    }
}