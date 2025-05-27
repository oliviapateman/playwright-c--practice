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

        public async Task GoToHomePage()
        {
            await _page.GotoAsync(url);
        }

        public async Task HoverCompanyDropDown()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Company" }).HoverAsync();
        }

        public async Task ClickMeetTheTeamOption()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Meet the Team" }).ClickAsync();
        }
    }
}