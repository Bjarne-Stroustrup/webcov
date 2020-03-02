using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public class WelcomePage : WikiPage
    {
        [Id("mw-content-text")]
        [Id("huvudsidaintro")]
        private WikiWelcomeBlock WelcomeBlock { get; set; }

        public string GetStatus()
        {
            return WelcomeBlock.GetStatus();
        }
    }
}