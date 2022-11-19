using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowPlaywriteAutomation.Drivers;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SpecflowPlaywriteAutomation.Hooks
{
    [Binding]
    public class Hooks1 :Driver
    {
        private IObjectContainer _objectContainer;

        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task FirstBeforeScenario()
        {
            await Initialize(); 
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _browser?.CloseAsync();
        }
    }
}
