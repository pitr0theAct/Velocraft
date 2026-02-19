using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Microsoft.AspNetCore.SignalR;
using OpenQA.Selenium;
using System.Globalization;

namespace Demo.PageObjects
{
    public class WebSlotBookingPage
    {
        public IWebDriver Driver { get; }

        WebItemWrap btnSelectSlot => new WebItemWrap("//div[@class='calendar-pub__welcome']/child::div[@class='calendar-pub__welcome-bottom']/child::div", 
            "Кнопка выбрать слот на первой страице");

        //Нужно поменять
        //Xpath указан до элемента списка и сейчас мы вибираем просто первое доступное время
        WebItemWrap btnSelectTime => new WebItemWrap("//div[@class = 'calendar-sharing__slot-item']", 
            "Время из списка доступного времени");
        
        WebItemWrap btnConfurmTime => new WebItemWrap("//div[@class = 'calendar-sharing__slot-item --selected']/child::div[@class='calendar-sharing__slot-select']", 
            "Кнопка подтверждения выбранного времени");

        WebItemWrap textAreaEmail => new WebItemWrap("//div[@class = 'calendar-sharing__form-input']/child::input[@inputmode='email']",
            "Поле для заполнения email");

        WebItemWrap textAreaName => new WebItemWrap("//input[contains(@class,'calendar-sharing__form-input') and not(@inputmode)]", 
            "Поле для заполнения имени");

        WebItemWrap btnCreateMeet => new WebItemWrap("//div[@class = 'calendar-pub-ui__btn']", "Кнопка 'Создать Встречу'");

        public WebSlotBookingPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public WebSlotBookingPage SelectSlotTime()
        {
            btnSelectSlot.Click(Driver);
            WaitersCore.Wait_s(5);//Ожидание появления выбора времени
            btnSelectTime.Click(Driver);
            WaitersCore.Wait_s(5);//Ожидание появления кнопки подтверждения
            btnConfurmTime.Click(Driver);
            return new WebSlotBookingPage(Driver);
        }

        public WebSlotBookingPage FillSlotData(string userName, string userEamil)
        {
            WaitersCore.Wait_s(5);//Ожидание появления формы заполнения информации о пользователе
            textAreaEmail.SendKeys(userEamil, Driver);
            textAreaName.SendKeys(userName, Driver);
            btnCreateMeet.Click(Driver);
            return new WebSlotBookingPage(Driver);
        }
    }
}
