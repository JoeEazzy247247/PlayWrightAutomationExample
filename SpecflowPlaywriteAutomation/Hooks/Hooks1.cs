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
        public IBrowserContext? _context { get; set; }
        public IPage _page { get; set; }

        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task FirstBeforeScenario()
        {
            //playwright
            _playwright = await Playwright.CreateAsync();

            //browser
            _browser = await _playwright.Chromium.LaunchAsync( 
                new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            //context
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions{
                ViewportSize = new ViewportSize{
                    Height = 1200,
                    Width = 1920
                },
            });
            //page
            _page = await _context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _browser?.CloseAsync();
        }
    }
}