using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTest.PageObjects;

namespace PlaywrightTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MotabilityNewTabTests : PageTest
{
    private MotabilityHomePage _homePage;
    private MotabilityCareersPage _careersPage;
    private IPage _newTab;

    [SetUp]
    public async Task Setup()
    {
        _homePage = new MotabilityHomePage(Page, Context);
        _careersPage = new MotabilityCareersPage(Page);
        await _homePage.GoToHomePage();
        await _homePage.ClickAcceptCookiesBtn();
        _newTab = await _homePage.OpenCareersTab();

    }

    [Test]
    public async Task OpenNewTab()
    {
        await Expect(_careersPage.GetCareersHeading(_newTab)).ToBeVisibleAsync();
    }

    [Test]
    public async Task SearchAnalystInNewTab()
    {
        await _careersPage.EnterJobKeywords(_newTab, "analyst");
        await _careersPage.ClickSearchJobs(_newTab);
        await Expect(_careersPage.GetAnalystFilter(_newTab)).ToBeVisibleAsync();
    }

}