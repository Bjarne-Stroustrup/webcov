using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public class IdAttribute : SelectorAttribute
    {
        private readonly string _id;

        public IdAttribute(string id)
        {
            _id = id;
        }

        public override By GetSelector()
        {
            return By.Id(_id);
        }
    }
}