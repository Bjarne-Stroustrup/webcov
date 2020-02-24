using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class ClassNameAttribute : SelectorAttribute
    {
        private readonly string _className;

        public ClassNameAttribute(string className)
        {
            _className = className;
        }

        public override By GetSelector()
        {
            return By.ClassName(_className);
        }
    }
}