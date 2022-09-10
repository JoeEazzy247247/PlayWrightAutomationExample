using BoDi;
using SpecflowPlaywriteAutomation.Pages;

namespace SpecflowPlaywriteAutomation.StepDefinitions
{
    [Binding]
    public sealed class DemoQaStepDefinitions
    {
        private readonly HomePage homePage;
        public DemoQaStepDefinitions(IObjectContainer objectContainer)
        {
            this.homePage = objectContainer.Resolve<HomePage>();
        }

        [Given(@"I am on demoqa page")]
        public async Task GivenAUserInTheCounterPage()
        {
            await homePage.GoToSite();
        }

        [When(@"I click elements")]
        public async Task WhenTheIncreaseButtonIsClickedTimes()
        {
            await homePage.ClickElement();
        }

        [When(@"I click TextBox")]
        public async Task WhenIClickTextBox()
        {
            await homePage.ClickTextBox();
        }

        [Then(@"I am on elements page")]
        public async void ThenTheCounterValueIs()
        {
            await homePage.isElementExist();
            homePage.isElementExist().Should().Be("Elements");
        }
    }
}