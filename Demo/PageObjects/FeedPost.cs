using OpenQA.Selenium;
using Demo.SeleniumFramework;

namespace Demo.PageObjects
{
    public class FeedPost
    {
        public FeedPost(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public bool AssertCommentReply(string secondComment)
        {
            new WebItemWrap($"//div[text()='{secondComment}']", "Текст ответа на сообщение").AssertTextContaining(secondComment, "Ответ на сообщение некорректный");
            throw new NotImplementedException();
        }

        //Нужно реализовать периход в раздел комментариев при нажатии на кнопку "комментировать"
        public PostCommentSection OpenCommentSection()
        {
            var btnCommentPost = new WebItemWrap("//a[contains(@id, 'blog-post') and text() ='Комментировать' ]", "Кнопка 'коментировать' под постом");
            return new PostCommentSection();
        }
    }
}
