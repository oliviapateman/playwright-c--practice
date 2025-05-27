using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.VisualBasic;

namespace PlaywrightTest.PageObjects
{
    public class MotabilityHomePage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _context;

        public MotabilityHomePage(IPage page, IBrowserContext context)
        {
            _page = page;
            _context = context;
        }

        private readonly string url = "https://www.motability.co.uk";
        private ILocator BulkConsentIFrame => _page.Locator("iframe#bulk-consent");
        private ILocator AcceptCookiesBtn => _page.GetByTitle("Accept preselected cookies");
        private ILocator CareersLink => _page.GetByText("Careers");
        private ILocator YourAccountBtn => _page.GetByRole(AriaRole.Link, new() { Name = "Your account" });

        public async Task GoToHomePage()
        {
            await _page.GotoAsync(url);
        }

        public async Task ClickAcceptCookiesBtn()
        {
            await AcceptCookiesBtn.ClickAsync();
        }

        public async Task<IFrame> GetBulkConsentFrameTitle()
        {
            IElementHandle frameElement = await BulkConsentIFrame.ElementHandleAsync();
            var frameContent = await frameElement.ContentFrameAsync();
            if (frameContent == null)
            {
                throw new InvalidOperationException("Can't get frame");
            }
            return frameContent;
        }

        public async Task<IPage> OpenCareersTab()
        {
            var newTab = await _context.RunAndWaitForPageAsync(async () =>
            {
                await CareersLink.ClickAsync();
            });
            return newTab;
        }

        public async Task GoToMyAccountPage()
        {
            await YourAccountBtn.ClickAsync();
        }
    }
}