using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class MeetTheTeamPage
    {
        private readonly IPage _page;

        public MeetTheTeamPage(IPage page)
        {
            _page = page;
        }

        private ILocator Heading => _page.Locator("h1 .lines");
        private ILocator TeamImages => _page.Locator(".team-container");

        public ILocator getHeading(){
            return Heading;
        }

        public ILocator getTeamImages(){
            return TeamImages;
        }
    }
}