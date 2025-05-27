using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class ContactPage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _context;

        public ContactPage(IPage page, IBrowserContext context)
        {
            _page = page;
            _context = context;
        }

        private ILocator PrivacyPolicyLink => _page.GetByRole(AriaRole.Link, new() { Name = "privacy policy" });
        public async Task<IPage> OpenPrivacyPolicyTab()
        {
            var newTab = await _context.RunAndWaitForPageAsync(async () =>
            {
                await PrivacyPolicyLink.ClickAsync();
            });
            return newTab;
        }
    }
}