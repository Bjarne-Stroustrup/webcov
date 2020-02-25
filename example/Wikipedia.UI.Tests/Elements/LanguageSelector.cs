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
        private Container LanguageLinks { get; set; }

        public ICollection<string> GetAvailableLangCodes()
        {
            return LanguageLinks.WebElements
                .Select(w => w.GetAttribute(LangAttributeName))
                .ToList();
        }

        public bool SelectLanguage(string languageCode)
        {
            var c = LanguageLinks
                .GetContainers();

            var innerHtml1 = c.ElementAt(0).WebElement.TagName;
            var innerHtml2 = c.ElementAt(1).WebElement.Text;
            var innerHtml3 = c.ElementAt(2).WebElement.Text;

            var langLink = c
                .FirstOrDefault(w =>
                    string.Equals(w.WebElement.GetAttribute(LangAttributeName), languageCode)
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