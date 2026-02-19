using Demo.BaseFramework;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;

namespace Demo.TestCases
{
    public class Case_Calendar_Web : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            return new List<ExecutableTestCase>
            {
                new ExecutableTestCase("Cоздание встречи внешним пользователем через слоты", homePage => SlotsCreateMeet(homePage)),
            };
        }

        public static void SlotsCreateMeet(WebHomePage homePage)
        {
            //Данные для заполнения информации слота(имя, email)
            string Name = "ExternalUser_" + HelperMethodsCore.GetDateTimeSalt();
            string Email = $"user_{HelperMethodsCore.GetDateTimeSalt()}@example.com";

            //Открываем портал
            Uri slotLink = homePage.SideMenu.
            //Открываем вкладку календарь в левом меню
                OpenCalendar().
            //Свободные слоты
                OpenSlotsMenu().
            //копируем ссылку
                CopySlotLink();

            //переходим по ссылке в новой вкладке
            var driver2 = DriverActionsWeb.CreateNewDriver();
            DriverActionsWeb.OpenUri(slotLink, driver2);
            //Открываем страницу для создания слота
            new WebSlotBookingPage(driver2).
            //Выбираем время
            SelectSlotTime()//До этого места все работает
            //Заполняем данные
            .FillSlotData(Name, Email);
            //Закрываем вкладку
            driver2.Close();

            //возвращаемся на страницу календаря
            homePage.SideMenu.OpenCalendar().
            //проверяем наличие события
            AssertMeeting(Name, Email);
        }
    }

}
