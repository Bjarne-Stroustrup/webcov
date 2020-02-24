using WebCov;
using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public class WikiPage : Container
    {
        [Xpath("//*[@id='p-logo']")]
        private Container Logo { get; set; }

        [Xpath("//*[@id='mw-content-text']")]
        private WikiWelcomeBlock WelcomeBlock { get; set; }

        public void ClickOnLogo()
        {
            Logo.WebElement.Click();
        }

        public string GetStatus()
        {
            return WelcomeBlock.GetStatus();
        }
    }
}