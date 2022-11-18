using BoDi;
using Microsoft.Playwright;

namespace SpecflowPlaywriteAutomation.Hooks
{
    [Binding]
    public class Hooks1 
    {
        private IObjectContainer _objectContainer;
        private IPlaywright? _playwright;
        public IBrowser? _browser { get; set; }
        public IPage? _page { get; set; }

        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task FirstBeforeScenario()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync( 
                new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 50 });

            _page = await _browser.NewPageAsync(new()
            { ViewportSize = new ViewportSize
                { Height = 1200, Width = 1920 },});
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _browser?.CloseAsync();
        }
    }
}