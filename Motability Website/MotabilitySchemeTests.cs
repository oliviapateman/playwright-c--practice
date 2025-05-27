using System.Net.Mime;
using System.Security.AccessControl;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTest.PageObjects;

namespace PlaywrightTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MotabilitySchemeTests : PageTest
{
    private MotabilityHomePage _homePage;
    private MotabilityCareersPage _careersPage;
    private MotabilitySignInPage _signInPage;

    [SetUp]
    public async Task Setup()
    {
        _homePage = new MotabilityHomePage(Page, Context);
        _careersPage = new MotabilityCareersPage(Page);
        _signInPage = new MotabilitySignInPage(Page);
        await _homePage.GoToHomePage();
        await _homePage.ClickAcceptCookiesBtn();
    }

    [Test]
    public async Task IFrameHasTitleBulkConsent()
    {
        var frameContent = await _homePage.GetBulkConsentFrameTitle();
        string titleText = await frameContent.TitleAsync();
        Assert.That(titleText, Is.EqualTo("Bulk Consent Manager"));
    }

    [Test]
    public async Task OpenNewTab()
    {
        // would be in SetUp() if had new tabs had their own test file
        IPage newTab = await _homePage.OpenCareersTab();
        await Expect(_careersPage.GetCareersHeading(newTab)).ToBeVisibleAsync();
    }

    [Test]
    public async Task SearchAnalystInNewTab()
    {
        IPage newTab = await _homePage.OpenCareersTab();
        await _careersPage.EnterJobKeywords(newTab, "analyst");
        await _careersPage.ClickSearchJobs(newTab);
        await Expect(_careersPage.GetAnalystFilter(newTab)).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidSignIn()
    {
        await _homePage.GoToMyAccountPage();
        await _signInPage.ClickDenyCookies();
        await _signInPage.EnterEmailAndPassword("test@fakeemail.com", "password1");
        await _signInPage.ClickSignInBtn();
        string expectedError = "The email and password that you entered do not match. Please review these and try again.";
        await Expect(_signInPage.GetSignInNotMatchingError()).ToHaveTextAsync(expectedError);
    }

}