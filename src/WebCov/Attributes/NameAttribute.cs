using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class NameAttribute : SelectorAttribute
    {
        private readonly string _name;

        public NameAttribute(string name)
        {
            _name = name;
        }

        public override By GetSelector()
        {
            return By.Name(_name);
        }
    }
}