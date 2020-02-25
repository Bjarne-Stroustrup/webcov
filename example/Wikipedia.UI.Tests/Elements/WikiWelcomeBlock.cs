using WebCov;
using WebCov.Attributes;

namespace Wikipedia.UI.Tests.Elements
{
    public class WikiWelcomeBlock : Container
    {
        [Xpath(".//p[@class='main-top-articleCount']")]
        private Container WikiStatusText { get; set; }

        public string GetStatus()
        {
            return WikiStatusText.WebElement.Text;
        }

    }
}