using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public class WelcomePage : WikiPage
    {
        [Xpath("//*[@id='mw-content-text']")]
        private WikiWelcomeBlock WelcomeBlock { get; set; }

        public string GetStatus()
        {
            return WelcomeBlock.GetStatus();
        }
    }
}