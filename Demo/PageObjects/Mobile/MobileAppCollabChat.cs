
using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Demo.TestEntities;

namespace Demo.PageObjects.Mobile
{
    public class MobileAppCollabChat
    {
        #region Elements
        MobileElement buttonBack => new MobileElement("//android.widget.FrameLayout[@content-desc=\"button_back\"]",
            "Кнопка 'назад' для выхода в чаты");
        MobileElement notificationButton => new MobileElement("//android.widget.TextView[@text=\"Уведомления\"]", "Кнопка уведомления");
        MobileElement chennelsButton => new MobileElement("//android.widget.TextView[@text=\"Каналы\"]", "Кнопка каналы");
        MobileElement collabButton => new MobileElement("//android.widget.TextView[@text=\"Коллабы\"]", "Кнопка коллабы");
        MobileElement collabInList(string collabName) => new MobileElement($"//android.widget.TextView[contains(@content-desc,\"list-item\") and @text=\"{collabName}\"]",
            $"Заголовок коллабы '{collabName}' в списке коллаб");
        #endregion

        /// <summary>
        /// Проверяет отображение названия коллабы
        /// </summary>
        /// <param name="collabName"></param>
        /// <returns></returns>
        public bool IsCollaborationNameDisplayed(string collabName)
        {
            buttonBack.Click();
            notificationButton.WaitDisplayed(50);
            notificationButton.Click();
            chennelsButton.Click();
            collabButton.WaitDisplayed(50);
            collabButton.Click();

            return collabInList(collabName).WaitDisplayed(50);
        }

        /// <summary>
        /// Проверяет отображение сообщения с описанием коллабы
        /// </summary>
        /// <param name="collab"></param>
        /// <returns></returns>
        public bool IsCollaborationDescriptionDisplayed(B24CollaborationEntity collab)
        {
            var collabText = new MobileElement($"//android.widget.TextView[@text='{collab.Description}']",
               $"Сообщение в чате коллабы с текстом '{collab.Description}'");

            bool isDescriptionDesplyed = WaitersCore.WaitForConditionReached(
                () => collabText.WaitDisplayed(50), 2, 50,
                $"Ожидание появления сообщения '{collab.Description}' в чате коллабы");

            return isDescriptionDesplyed;
        }

        /// <summary>
        /// Проверяет отображение сообщения о приглашении модератора
        /// </summary>
        /// <param name="testModerator"></param>
        /// <returns></returns>
        public bool IsModeratorInvited(User testModerator)
        {
            var mentionMassage = new MobileElement($"//android.widget.TextView[@content-desc=\"message_with_mention\" " +
                $"and contains(@text, \"{testModerator.Name}\")]", $"Сообщение в чате о приглашении модератора '{testModerator.Name}'");

            bool isModeratorDisplayed = WaitersCore.WaitForConditionReached(
                () => mentionMassage.WaitDisplayed(50), 2, 50,
                $"Ожидание появления соббщения о приглашении модератора '{testModerator.Name}'");

            return isModeratorDisplayed;

        }
    }
}
