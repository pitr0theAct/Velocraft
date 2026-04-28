using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;
using System.Data.SqlTypes;

namespace Demo.PageObjects
{
    /// <summary>
    /// Вкладка Свободные слоты на странице календаря
    /// </summary>
    public class SlotsMenu
    {
        WebItemWrap btnGetLink => new WebItemWrap("//span[@class='ui-btn ui-btn-success ui-btn-round ui-btn-no-caps calendar-sharing__dialog-copy']",
            "Кнопка Копировать ссылку");

        public SlotsMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Копирует ссылку на встречу в буфер обмена и возвращает её
        /// </summary>
        public Uri CopySlotLink()
        {
            btnGetLink.WaitDisplayed(50, Driver);//Ожидание появления кнопки 'Копировать ссылку'
            btnGetLink.Click(Driver);
            string link = ClipboardWrapper.GetText();
            Uri uri = new Uri(link);
            return uri;
        }
    }
}
