


using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class PostCommentSection
    {
        WebItemWrap commentTextAreaFrame => new WebItemWrap("//iframe[@class='bx-editor-iframe']", "фрейм который содержит текстовое поле комментария");

        WebItemWrap commentTextArea => new WebItemWrap("//body[@contenteditable='true']", "Текстовое поле комментария");

        WebItemWrap sendCommentButton => new WebItemWrap("//button[contains(@id, 'blogCommentForm') and text() ='Отправить']", "Кнопка отправить комментарий");

        WebItemWrap replyCommentButton => new WebItemWrap("//a[contains(@id, 'actions-reply') and text() ='Ответить']", "Кнопка ответить на комментарий");

        public PostCommentSection(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public PostCommentSection FillCommentText(string text)
        {
            commentTextAreaFrame.SwitchToFrame(Driver);
            commentTextArea.SendKeys(text, Driver);
            commentTextAreaFrame.SwitchToDefaultContent(Driver);
            return new PostCommentSection(Driver);
        }

        public FeedPage SendComment()
        {
            sendCommentButton.Click(Driver);
            //Ждем пока кнопка отправки комментария отображается
            sendCommentButton.WaitWhileDisplayed(50);
            return new FeedPage(Driver);
        }

        public PostCommentSection CommentReply()
        {
            replyCommentButton.Click(Driver);
            new WebItemWrap("//div[contains(@class, 'add-box-outer-form-shown')]", "Ожидание появления поля для ввода комментария").WaitDisplayed(50, Driver);
            return new PostCommentSection(Driver);
        }
    }
}
