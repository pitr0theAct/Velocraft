


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
            WaitersCore.Wait_s(5);//Ожидание пока отправится комментарий
            return new FeedPage(Driver);
        }

        public PostCommentSection CommentReply()
        {
            replyCommentButton.Click(Driver);
            WaitersCore.Wait_s(5);//Ожидание пока не появится поля для ввода комментария 
            return new PostCommentSection(Driver);
        }
    }
}
