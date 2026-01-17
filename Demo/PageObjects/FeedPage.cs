using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class FeedPage
    {
        public FeedPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public FeedPostForm OpenAddPostForm()
        {
            var btnPostCreate = new WebItemWrap("//div[@id='microoPostFormLHE" +
                "_blogPostForm_inner']", "Область в ленте 'Написать сообщение'");
            btnPostCreate.Click(Driver);
            return new FeedPostForm(Driver);
        }

        public FeedPage AddComment(string commentText)
        {
            return new FeedPage();
        }

        public FeedPage FeedSearch(string Text)
        {
            return new FeedPage();
        }

        public FeedPage CommentReply(string secondComment)
        {
            return new FeedPage();
        }

        public bool AssertCommentReply(string secondComment)
        {
            new WebItemWrap($"//div[text()='{secondComment}']", "Текст ответа на сообщение").AssertTextContaining(secondComment, "Ответ на сообщение некорректный");
            throw new NotImplementedException();
        }
    }
}
