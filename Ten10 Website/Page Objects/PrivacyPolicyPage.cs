using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class PrivacyPolicyPage
    {
        private readonly IPage _page;

        public PrivacyPolicyPage(IPage page)
        {
            _page = page;
        }

        public ILocator GetHeading(IPage page)
        {
            return page.Locator("span.lines");
        }
    }
}