using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Microsoft.AspNetCore.SignalR;
using OpenQA.Selenium;
using System.Globalization;

namespace Demo.PageObjects
{
    /// <summary>
    /// Страница для создания встречи внешним пользователем
    /// </summary>
    public class WebSlotBookingPage
    {
        public IWebDriver Driver { get; }

        WebItemWrap btnSelectSlot => new WebItemWrap("//div[@class='calendar-pub__welcome']/child::div[@class='calendar-pub__welcome-bottom']/child::div", 
            "Кнопка выбрать слот на первой страице");

        //Xpath указан до элемента списка и мы выбираем просто первое доступное время
        WebItemWrap btnSelectTime => new WebItemWrap("//div[@class = 'calendar-sharing__slot-item']", 
            "Время из списка доступного времени");
        
        WebItemWrap btnConfurmTime => new WebItemWrap("//div[@class = 'calendar-sharing__slot-item --selected']/child::div[@class='calendar-sharing__slot-select']", 
            "Кнопка подтверждения выбранного времени");

        WebItemWrap textAreaEmail => new WebItemWrap("//div[@class = 'calendar-sharing__form-input']/child::input[@inputmode='email']",
            "Поле для заполнения email");

        WebItemWrap textAreaName => new WebItemWrap("//input[contains(@class,'calendar-sharing__form-input') and not(@inputmode)]", 
            "Поле для заполнения имени");

        WebItemWrap btnCreateMeet => new WebItemWrap("//div[@class = 'calendar-pub-ui__btn']", "Кнопка 'Создать Встречу'");

        WebItemWrap meetCreatedIcon => new WebItemWrap("//div[@class='calendar-sharing__form-result_icon --accept']",
            "Значок галочки подтверждающий создание встречи");

        public WebSlotBookingPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        /// <summary>
        /// Меню выбора времени для назначения встречи
        /// </summary>
        public WebSlotBookingPage SelectSlotTime()
        {
            btnSelectSlot.Click(Driver);
            btnSelectTime.WaitDisplayed(50, Driver);//Ожидание появления выбора времени
            btnSelectTime.Click(Driver);
            btnConfurmTime.WaitDisplayed(50, Driver);//Ожидание появления кнопки подтверждения
            btnConfurmTime.Click(Driver);
            return new WebSlotBookingPage(Driver);
        }

        /// <summary>
        /// Заполнение имени и почты внешнего пользователя
        /// </summary>
        public WebSlotBookingPage FillSlotData(string userName, string userEamil)
        {
            textAreaEmail.WaitDisplayed(50, Driver);//Ожидание появления формы заполнения информации о пользователе
            textAreaEmail.SendKeys(userEamil, Driver);
            textAreaName.SendKeys(userName, Driver);
            btnCreateMeet.Click(Driver);
            meetCreatedIcon.WaitDisplayed(50, Driver);//Ожидание появления сообщения об успешном создании встречи
            return new WebSlotBookingPage(Driver);
        }
    }
}
