using OpenQA.Selenium;
using SeleniumAutomation2.UiCore;

namespace SeleniumAutomation2.GMailPages;

public class MessagePage
{
    private const string MessageSubject = @"//h2 [text()='{0}']";
    private const string MessageBody = @"//div[@dir='ltr' and text()='{0}']";
    private static Element ReplyButton => new(By.XPath("//span[@role='link' and text()='Ответить']"));
    private static Element MessageInput => new(By.XPath("//div[@aria-label='Текст письма']"));
    private static Element SendButton => new(By.XPath("//div[@role = 'button' and contains(@data-tooltip,'Отправить')]"));

    public bool GetMessageSubject(string subject)
    {
        return new Element(By.XPath(string.Format(MessageSubject, subject))).Displayed;
    }

    public bool GetMessageBody(string body)
    {
        return new Element(By.XPath(string.Format(MessageBody, body))).Displayed;
    }

    public void Reply(string message)
    {
        ReplyButton.Click();
        MessageInput.SendKeys(message);
        SendButton.Click();
    }
}