using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SpecflowPlaywriteAutomation.Drivers
{
    public class Driver
    {
        private IPlaywright? _playwright;
        public IBrowser? _browser { get; set; }
        public IPage? _page { get; set; }

        public async Task<IPage> Initialize()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                { Headless = false, SlowMo = 50 });

            _page = await _browser.NewPageAsync(new()
            {
                ViewportSize = new ViewportSize
                { Height = 1200, Width = 1920 },
            });
            return _page;
        }
    }
}
