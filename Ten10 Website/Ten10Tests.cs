using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTest.PageObjects;

namespace PlaywrightTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Ten10Tests : PageTest
{
    private HomePage _homePage;
    private ContactPage _contactPage;
    private PrivacyPolicyPage _privacyPolicyPage;

    [SetUp]
    public async Task Setup()
    {
        _homePage = new HomePage(Page);
        _contactPage = new ContactPage(Page, Context);
        _privacyPolicyPage = new PrivacyPolicyPage(Page);
        await _homePage.GoToHomePage();
    }

    [Test]
    public async Task PrivacyPolicyOpensNewTab()
    {
        await _homePage.ClickContactBtn();
        IPage newTab = await _contactPage.OpenPrivacyPolicyTab();
        await Expect(_privacyPolicyPage.GetHeading(newTab)).ToHaveTextAsync("Privacy Policy");
    }
}