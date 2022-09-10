using BoDi;
using Microsoft.Playwright;
using SpecflowPlaywriteAutomation.Hooks;

namespace SpecflowPlaywriteAutomation.Pages
{
    public class HomePage
    {
        private IPage _page;
        private readonly ILocator Elements;
        private readonly ILocator TextBox;
        private readonly ILocator HeaderTxt;
        private string url => "https://demoqa.com/";
        public HomePage(IPage page)
        {
            this._page = page;
            Elements = _page.Locator("[class='card mt-4 top-card']");
            TextBox = _page.Locator("[id='item-0']");
            HeaderTxt = _page.Locator("div[class='main-header']");
        }

        public async Task GoToSite() => await _page.GotoAsync(url);
        public async Task ClickElement() => await Elements.Nth(0).ClickAsync();
        public async Task ClickTextBox()
        {
            await TextBox.Nth(0).ClickAsync();
            await _page.FillAsync("#userName", "Joseph");
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = @$"C:\Users\joeea\source\repos\SpecflowPlaywriteAutomation\ScreenShots\Image-{DateTime.Now.ToString("yyyy/MM/dd HHmmssfff")}.png",
                Type = ScreenshotType.Png,
                FullPage = true,
            });
        }

        public async Task<string> isElementExist()=> 
            await HeaderTxt.InnerTextAsync();
    }
}
