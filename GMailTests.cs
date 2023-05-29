using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation2.UiCore;

namespace SeleniumAutomation2;

[TestClass]
public class GMailTests : TestBase
{
    [TestMethod]
    public void GMail_Test()
    {
        // Login as first user
        NavigateToGMail();
        SignInPage.ChangeLanguageToEnglish();
        SignInPage.Login(TestData.Username1);

        // Write a message
        var subject = CommonHelper.GenerateRandomString(5);
        var message = CommonHelper.GenerateRandomString(10);

        MainPage.ClickWriteButton();
        EmailMessageModal.SendEmail(TestData.Username2, subject, message);

        // Logout from first user
        Logout();

        // Login as second user
        SignInPage.ChangeLanguageToEnglish();
        SignInPage.ClickAnotherUserLink();
        SignInPage.Login(TestData.Username2);

        // Open Received Message
        NavigateToGMail();
        MainPage.SelectMessageBySubject(subject);

        // Validate Message Content
        Assert.IsTrue(MessagePage.GetMessageSubject(subject));
        Assert.IsTrue(MessagePage.GetMessageBody(message));

        // Reply on message
        var replyMessage = CommonHelper.GenerateRandomString(10);
        MessagePage.Reply(replyMessage);

        // Login back as first user
        Logout();
        SignInPage.ChangeLanguageToEnglish();
        SignInPage.SelectRememberedUser("alexa");
        NavigateToGMail();
        MainPage.SelectMessageBySubject(subject);

        // Validate Reply Content
        Assert.IsTrue(MessagePage.GetMessageBody(replyMessage));
    }
}