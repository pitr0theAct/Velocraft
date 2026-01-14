using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в ленту
    /// </summary>
    public class FeedPostForm
    {
        public FeedPostForm(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public bool IsRecipientPresent(string recipientName)
        {
            var recipientsArea = new WebItemWrap("//div[@id='entity-selector-oPostFormLHE" +
                "_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            bool isRecipientPresent = WaitersCore.WaitForConditionReached(() => recipientsArea.AssertTextContaining(recipientName, default, Driver), 2, 6,
                $"Ожидание появления '{recipientName}' " +
                $"в '{recipientsArea.Description}'");
            return isRecipientPresent;
        }
    }
}
