using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class LogInFeatureSteps
{
    private IBrowser browser;
    private IPage page;

    public LogInFeatureSteps() //Constructor to initialize browser 
    {
        var playwright = Playwright.CreateAsync().Result;
        browser = playwright.Chromium.LaunchAsync().Result;
    }


    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        page = browser.NewPageAsync();
        page.GoToAsync("https://example.com/login").Wait();
    }

    [When(@"I enter valid credentials")]
    public void WhenIEnterValidCredentials()
    {
        page.FillAsync("#username", "testuser").Wait();
        page.FillAsync("#password", "password123").Wait();
        page.ClickAsync("#submit").Wait();
    }

    [Then(@"I should be redirected to the dashboard")]
    public void ThenIShouldBeRedirectedToTheDashboard()
    {
        Assert.AreEqual("https://example.com/dashboard", page.Url);
    }
}
