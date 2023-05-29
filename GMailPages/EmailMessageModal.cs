using OpenQA.Selenium;
using SeleniumAutomation2.UiCore;

namespace SeleniumAutomation2.GMailPages;

public class EmailMessageModal
{

    private static Element MailToInput => new(By.XPath("//div[@role='presentation']//input[@type='text']"));
    private static Element SubjectInput => new(By.XPath("//input[@name='subjectbox']"));
    private static Element MessageInput => new(By.XPath("//div[@aria-label='Текст письма' and @role = 'textbox']"));
    private static Element SendButton => new(By.XPath("//div[@role = 'button' and contains(@data-tooltip,'Отправить')]"));

    public void SendEmail(string mailTo, string subject, string message)
    {
        MailToInput.SendKeys(mailTo);
        SubjectInput.SendKeys(subject);
        MessageInput.SendKeys(message);
        SendButton.Click();
    }
}