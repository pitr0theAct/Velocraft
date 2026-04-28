using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    /// <summary>
    /// Страница календаря
    /// </summary>
    public class CalendarPage
    {
        WebItemWrap btnOpenSlotsMenu => new WebItemWrap("//div[contains(@id, 'sharing-container')]", "Кнопка свободные слоты");

        public CalendarPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Открывает меню слотов на странице календаря
        /// </summary>
        public SlotsMenu OpenSlotsMenu()
        {
            btnOpenSlotsMenu.Click(Driver);
            return new SlotsMenu(Driver);
        }

        /// <summary>
        /// Проверяет наличие встречи с указанным участником на странице календаря
        /// </summary>
        public bool AssertMeeting(string userName)
        {
            bool isMeetingexist = new WebItemWrap($"//span[contains(text(), '{userName}')]", "Текст о встрече на странице календаря").AssertTextContaining(userName, "Имя участника встречи некорректное");
            return isMeetingexist;
        }
    }
}
