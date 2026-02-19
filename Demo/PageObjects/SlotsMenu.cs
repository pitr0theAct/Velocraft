using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class SlotsMenu
    {
        public SlotsMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public Uri CopySlotLink()
        {
            Uri link = null;
            return link;
        }
    }
}
