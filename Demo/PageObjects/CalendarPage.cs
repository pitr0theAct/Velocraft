using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class CalendarPage
    {
        public CalendarPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

       public SlotsMenu OpenSlotsMenu()
        {
            return new SlotsMenu(Driver);
        }

        public bool AssertMeeting(string meetingName, string userName, string userEamil)
        {
            throw new NotImplementedException();
        }
    }
}
