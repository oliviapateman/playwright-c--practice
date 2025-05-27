using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class MotabilityCareersPage
    {
        private readonly IPage _page;

        public MotabilityCareersPage(IPage page)
        {
            _page = page;
        }

        public ILocator GetCareersHeading(IPage page)
        {
            return page.GetByRole(AriaRole.Heading, new() { Name = "Search vacancies" });
        }

        public ILocator GetAnalystFilter(IPage page)
        {
            return page.GetByTitle("analyst");
        }

        public async Task EnterJobKeywords(IPage tab, string keywords)
        {
            await tab.GetByPlaceholder("Enter Keywords").FillAsync(keywords);
        }

        public async Task ClickSearchJobs(IPage tab)
        {
            await tab.GetByText("Search Jobs").ClickAsync();
        }
    }
}