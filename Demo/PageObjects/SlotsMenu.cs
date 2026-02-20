using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;
using System.Data.SqlTypes;

namespace Demo.PageObjects
{
    public class SlotsMenu
    {
        WebItemWrap btnGetLink => new WebItemWrap("//span[@class='ui-btn ui-btn-success ui-btn-round ui-btn-no-caps calendar-sharing__dialog-copy']",
            "Кнопка Копировать ссылку");

        public SlotsMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public Uri CopySlotLink()
        {
            btnGetLink.WaitDisplayed(50, Driver);//Ожидание появления кнопки 'создайте тестовую встречу'
            btnGetLink.Click(Driver);
            string link = ClipboardWrapper.GetText();
            Uri uri = new Uri(link);
            return uri;
        }
    }
}
