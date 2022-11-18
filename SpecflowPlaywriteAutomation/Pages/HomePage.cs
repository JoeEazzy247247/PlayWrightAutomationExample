using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace SpecflowPlaywriteAutomation.Pages
{
    public class HomePage
    {
        private IPage _page;
        private string url => "https://demoqa.com/";
        public HomePage(IPage page) => this._page = page;

        #region locators
        private ILocator Elements => _page.Locator("[class='card mt-4 top-card']");
        private ILocator TextBox => _page.Locator("[id='item-0']");
        private ILocator HeaderTxt => _page.Locator("div[class='main-header']");
        #endregion locators

        #region methods
        public async Task GoToSite() =>
            await _page.GotoAsync(url, new()
            { WaitUntil = WaitUntilState.NetworkIdle });
        
        //public async Task ClickElement() => await Elements.Nth(0).ClickAsync();
        public async Task ClickElement()
        {
            await _page.RunAndWaitForResponseAsync(async () =>
            {
                await Elements.Filter(new() { HasTextString = "Elements" }).ClickAsync();
            }, x=>x.Status == 200 || x.StatusText == "OK");
        }

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
        #endregion methods
    }
}
