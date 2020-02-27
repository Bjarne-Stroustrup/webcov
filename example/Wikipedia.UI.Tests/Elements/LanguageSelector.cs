using System.Collections.Generic;
using System.Linq;
using WebCov;
using WebCov.Attributes;
using WebCov.Extensions;

namespace Wikipedia.UI.Tests.Elements
{
    // [Xpath("//*[@id='p-lang']")]
    [Id("p-lang")]
    public class LanguageSelector : Container
    {
        private const string LangAttributeName = "lang";

        [Xpath(".//li")]
        private LanguageListItem LanguageList { get; set; }

        public ICollection<string> GetAvailableLangCodes()
        {
            return LanguageList.WebElements
                .Select(w => w.GetAttribute(LangAttributeName))
                .ToList();
        }

        public bool SelectLanguage(string languageCode)
        {
            var langLinkIndex = LanguageList.WebElements
                .IndexOfFirst(w => w.GetAttribute(LangAttributeName) == languageCode);

            if (langLinkIndex < 0)
            {
                return false;
            }

            var langLink = LanguageList.Nth(langLinkIndex);
            langLink.WebElement.Click();
            return true;
        }
    }
}