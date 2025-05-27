using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        private readonly string url = "https://ten10.com";
        private ILocator CompanyDropDown => _page.GetByRole(AriaRole.Link, new() { Name = "Company" });
        private ILocator MeetTeamOption => _page.GetByRole(AriaRole.Link, new() { Name = "Meet the Team" });
        private ILocator ContactBtn => _page.GetByTitle("Contact");

        public async Task GoToHomePage()
        {
            await _page.GotoAsync(url);
        }

        public async Task HoverCompanyDropDown()
        {
            await CompanyDropDown.HoverAsync();
        }

        public async Task ClickMeetTheTeamOption()
        {
            await MeetTeamOption.ClickAsync();
        }

        public async Task ClickContactBtn()
        {
            await ContactBtn.ClickAsync();
        }
    }
}