using WebCov;
using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public class LanguageLink : Container
    {
        private const string LangAttributeName = "lang";

        [Xpath("./a")]
        private Container Link { get; set; }


        public string GetLangCode()
        {
            return Link.WebElement.GetAttribute(LangAttributeName);
        }
    }
}