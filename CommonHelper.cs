using OpenQA.Selenium;

namespace SeleniumAutomation2;

public class CommonHelper
{
    public string GenerateRandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
        );
        return result;
    }
}