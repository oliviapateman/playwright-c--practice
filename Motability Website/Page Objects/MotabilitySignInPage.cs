using Microsoft.Playwright;

namespace PlaywrightTest.PageObjects
{
    public class MotabilitySignInPage
    {
        private readonly IPage _page;

        public MotabilitySignInPage(IPage page)
        {
            _page = page;
        }

        private ILocator DenyCookiesBtn => _page.GetByTitle("Deny all cookies");
        private ILocator EmailInputBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "email" });
        private ILocator PasswordInputBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "password" });
        private ILocator SignInBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });
        private ILocator SignInNotMatchingError => _page.Locator(".general-error div");

        public async Task ClickDenyCookies()
        {
            await DenyCookiesBtn.ClickAsync();
        }

        public async Task EnterEmailAndPassword(string email, string password)
        {
            await EmailInputBox.FillAsync(email);
            await PasswordInputBox.FillAsync(password);
        }

        public async Task ClickSignInBtn()
        {
            await SignInBtn.ClickAsync();
        }

        public ILocator GetSignInNotMatchingError()
        {
            return SignInNotMatchingError;
        }
    }
}