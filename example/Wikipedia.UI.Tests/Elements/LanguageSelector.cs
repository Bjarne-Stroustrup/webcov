using System.Collections.Generic;
using System.Linq;
using WebCov;
using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    // [Xpath("//*[@id='p-lang']")]
    [Id("p-lang")]
    public class LanguageSelector : Container
    {
        private const string LangAttributeName = "lang";

        [Xpath(".//li/a")]
        private LanguageListItem LanguageList { get; set; }

        public ICollection<string> GetAvailableLangCodes()
        {
            return LanguageList.WebElements
                .Select(w => w.GetAttribute(LangAttributeName))
                .ToList();
        }

        public bool SelectLanguage(string languageCode)
        {
            var langLink = LanguageList.WebElements
                .FirstOrDefault(w => w.GetAttribute(LangAttributeName) == languageCode);

            if (langLink == null)
            {
                return false;
            }

            langLink.Click();
            return true;
        }
    }
}