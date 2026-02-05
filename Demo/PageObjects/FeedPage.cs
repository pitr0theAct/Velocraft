using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class FeedPage
    {
        WebItemWrap feedSearchButton => new WebItemWrap("//span[@class='main-ui-item-icon main-ui-search']", "Поле поиска по ленте");
        WebItemWrap searchTextArea => new WebItemWrap("//input[@id='LIVEFEED_search']", "Текстовое поле для поиска по ленете");

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

        public FeedPost FeedSearch(string postText)
        {
            //Ожидание пока опубликуется пост
            WaitersCore.Wait_s(5);
            feedSearchButton.Click(Driver);
            searchTextArea.SendKeys(postText, Driver);
            return new FeedPost(Driver);
        }

    }
}
