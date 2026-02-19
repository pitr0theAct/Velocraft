using Demo.SeleniumFramework;
using OpenQA.Selenium;
using System.Data.SqlTypes;

namespace Demo.PageObjects
{
    public class SlotsMenu
    {
        WebItemWrap btnGetLink => new WebItemWrap("//div[@class='calendar-sharing__dialog-notify']/a", "Кнопка создайте тестовую встречу");

        public SlotsMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public Uri CopySlotLink()
        {
            string link = btnGetLink.GetAttribute("href");
            Uri uri = new Uri(link);
            return uri;
        }
    }
}
