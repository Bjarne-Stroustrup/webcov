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
        [Xpath(".//li")]
        private LanguageLink LanguageLinks { get; set; }

        public ICollection<string> GetAvailableLangCodes()
        {
            return LanguageLinks.ToSelfCollection()
                .Select(w => w.GetLangCode())
                .ToList();
        }

        public bool SelectLanguage(string languageCode)
        {
            var c = LanguageLinks.ToSelfCollection();

            var langLink = c
                .FirstOrDefault(w =>
                    string.Equals(w.GetLangCode(), languageCode)
                );

            if (langLink == null)
            {
                return false;
            }

            langLink.WebElement.Click();
            return true;
        }
    }
}