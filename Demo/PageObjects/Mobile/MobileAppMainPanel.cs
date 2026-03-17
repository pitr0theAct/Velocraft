
using Demo.SeleniumFramework;

namespace Demo.PageObjects.Mobile
{
    /// <summary>
    /// Главная панель приложения
    /// </summary>
    public class MobileAppMainPanel
    {
        MobileElement massangerTab => new MobileElement("//android.widget.FrameLayout[contains(@content-desc,'bottombar_tab_chats')]", "Таб 'Мессенджер'");

        public MobileAppTasksListPage SelectTasks()
        {
            var tasksTab = new MobileElement("//android.widget.TextView" +
                "[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_title\" and @text=\"Tasks\"]",
                "Таб 'Задачи'");
            tasksTab.Click();

            return new MobileAppTasksListPage();
        }

        /// <summary>
        /// Переходит во вкладку мессенджер из нижнего меню приложения
        /// </summary>
        /// <returns></returns>
        public MobileAppMassengerPage SelectMassenger()
        {
            massangerTab.WaitDisplayed(50);
            massangerTab.Click();
            return new MobileAppMassengerPage();
        }
    }
}