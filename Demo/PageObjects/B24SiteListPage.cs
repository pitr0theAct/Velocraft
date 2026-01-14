using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class B24SiteListPage
    {
        public B24SiteListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
    }
}