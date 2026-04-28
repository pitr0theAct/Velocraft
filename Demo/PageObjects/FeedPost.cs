using OpenQA.Selenium;
using Demo.SeleniumFramework;
using Demo.BaseFramework;

namespace Demo.PageObjects
{
    public class FeedPost
    {
        WebItemWrap btnCommentPost = new WebItemWrap("//a[contains(@id, 'blog-post') and text() ='Комментировать' ]", "Кнопка 'коментировать' под постом");

        public FeedPost(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public bool AssertCommentReply(string secondComment)
        {
            bool isReplyExist = new WebItemWrap($"//div[contains(text(), '{secondComment}')]", "Текст ответа на сообщение").AssertTextContaining(secondComment, "Ответ на сообщение некорректный");
            return isReplyExist;
        }

        public PostCommentSection OpenCommentSection()
        {
            btnCommentPost.Click(Driver);
            return new PostCommentSection(Driver);
        }
    }
}
