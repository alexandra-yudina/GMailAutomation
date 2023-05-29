using OpenQA.Selenium;
using SeleniumAutomation2.UiCore;

namespace SeleniumAutomation2.GMailPages;

public class MainPage
{
    private static Element WriteButton => new(By.XPath("//div[@role='button' and text()='Написать']"));
    private const string LetterBySubject = @"(//span[text()='{0}'])[2]";

    public void ClickWriteButton() => WriteButton.Click();

    public void SelectMessageBySubject(string subject)
    {
        new Element(By.XPath(string.Format(LetterBySubject, subject))).Click();
    }

}