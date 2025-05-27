using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTest.PageObjects;

namespace PlaywrightTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MeetTheTeamTests : PageTest
{
    private HomePage _homePage;
    private MeetTheTeamPage _meetTheTeamPage;

    [SetUp]
    public async Task Setup()
    {
        _homePage = new HomePage(Page);
        _meetTheTeamPage = new MeetTheTeamPage(Page);
        await _homePage.GoToHomePage();
        await _homePage.HoverCompanyDropDown();
        await _homePage.ClickMeetTheTeamOption();
    }

    [Test]
    public async Task HasMeetTheTeamInURL()
    {
        await Expect(Page).ToHaveURLAsync(new Regex("/*meet-the-team"));
    }

    [Test]
    public async Task CheckMeetTheTeamIsTheHeading()
    {
        await Expect(_meetTheTeamPage.getHeading()).ToHaveTextAsync("Meet the Team");
    }

    [Test]
    public async Task CheckTeamHas26Images()
    {
        await Expect(_meetTheTeamPage.getTeamImages()).ToHaveCountAsync(26);
    }
}