using System;
using System.Linq;
using WebCov;
using WebCov.Attributes;
using WebCov.Extensions;

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

        public bool WaitLogoExists(TimeSpan timeout)
        {
            return Logo.WaitUntilExist(timeout);
        }

        public bool IsLogoExists()
        {
            var webElement = Logo.WebElement;
            return webElement != null && webElement.Displayed;
        }
    }
}