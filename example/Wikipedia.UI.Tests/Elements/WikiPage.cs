using System.Linq;
using WebCov;
using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public abstract class WikiPage : Container
    {
        // [Xpath("//*[@id='p-logo']")]
        [Id("p-logo")]
        protected  Container Logo { get; set; }

        public LanguageSelector LanguageSelector { get; set; }

        public void ClickOnLogo()
        {
            Logo.WebElement.Click();
        }
    }
}