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

        public FeedPost FeedSearch(string Text)
        {
            return new FeedPost();
        }

    }
}
