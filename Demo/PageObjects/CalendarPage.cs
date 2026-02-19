using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class CalendarPage
    {
        WebItemWrap btnOpenSlotsMenu => new WebItemWrap("//div[contains(@id, 'sharing-container')]", "Кнопка свободные слоты");

        public CalendarPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

       public SlotsMenu OpenSlotsMenu()
        {
            btnOpenSlotsMenu.Click(Driver);
            return new SlotsMenu(Driver);
        }

        public bool AssertMeeting(string userName, string userEamil)
        {
            throw new NotImplementedException();
        }
    }
}
