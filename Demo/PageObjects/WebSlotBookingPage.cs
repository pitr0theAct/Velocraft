using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class WebSlotBookingPage
    {
        public IWebDriver Driver { get; }

        public WebSlotBookingPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public WebSlotBookingPage SelectSlotTime()
        {
            return new WebSlotBookingPage(Driver);
        }

        public WebSlotBookingPage FillSlotData(string meetingName, string userName, string userEamil)
        {
            return new WebSlotBookingPage(Driver);
        }
    }
}
