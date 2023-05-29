using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation2.GMailPages;

namespace SeleniumAutomation2.UiCore;

public class TestBase
{
    internal static IWebDriver Driver;
    private const string DriverPath = @"..\SeleniumAutomation";
    private const string GMailUrl = "https://mail.google.com/";
    private const string LogoutUrl = "https://accounts.google.com/Logout";

    public MainPage MainPage = new();
    public SignInPage SignInPage = new();
    public EmailMessageModal EmailMessageModal = new();
    public MessagePage MessagePage = new();
    public CommonHelper CommonHelper;

    private static Element AlertXButton => new(By.XPath("//div[@aria-live and @role='alert']//div//div//div"));

    [TestInitialize]
    public void TestInitialize()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");
        Driver = new ChromeDriver(DriverPath, options);
        CommonHelper = new CommonHelper(Driver);
    }

    public void NavigateToGMail()
    {
        Driver.Navigate().GoToUrl(GMailUrl);
    }

    public void Logout()
    {
        if(AlertXButton.Displayed)
            AlertXButton.Click();
        Driver.Navigate().GoToUrl(LogoutUrl);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Driver.Close();
        Driver.Quit();
    }
}