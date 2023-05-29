using OpenQA.Selenium;
using SeleniumAutomation2.UiCore;

namespace SeleniumAutomation2.GMailPages;

public class SignInPage
{
    private static Element ChangeLanguageDropdown => new(By.XPath("//div[@aria-haspopup]"));
    private static Element EnglishLanguageOption => new(By.XPath("//li[@data-value='en-GB']"));
    private static Element EmailInput => new(By.XPath("//input[@type='email']"));
    private static Element PasswordInput => new(By.XPath("//input[@type='password']"));
    private static Element NextButton => new(By.XPath("//span[text()='Next']"));
    private static Element UseAnotherAccountLink => new(By.XPath("//div[text()='Use another account']"));
    private const string RememberedUser = @"//div[text()='{0}']";

    public void ChangeLanguageToEnglish()
    {
        ChangeLanguageDropdown.Click();
        EnglishLanguageOption.Click();
    }

    public void Login(string emailAddress, string password = TestData.Password)
    {
        EmailInput.SendKeys(emailAddress);
        NextButton.Click();
        PasswordInput.SendKeys(password);
        NextButton.Click();
    }

    public void ClickAnotherUserLink()
    {
        UseAnotherAccountLink.Click();
    }

    public void SelectRememberedUser(string user, string password = TestData.Password)
    {
        new Element(By.XPath(string.Format(RememberedUser, user))).Click();
        PasswordInput.SendKeys(password);
        NextButton.Click();
    }
}