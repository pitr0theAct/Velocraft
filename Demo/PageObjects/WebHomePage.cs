using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class WebHomePage
    {
        public IWebDriver Driver { get; }

        public WebHomePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public SiteLeftMenu SideMenu => new SiteLeftMenu(Driver);

    }
}
