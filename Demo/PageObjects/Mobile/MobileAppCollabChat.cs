
using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Demo.TestEntities;

namespace Demo.PageObjects.Mobile
{
    public class MobileAppCollabChat
    {

        /// <summary>
        /// Проверяет отображение названия коллабы
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsCollaborationNameDisplayed(string name)
        {
            var collabTitle = new MobileElement($"//android.widget.TextView[@content-desc='{name}')]",
                $"Заголовок коллабы с текстом {name}");

            bool isNameDisplayed = WaitersCore.WaitForConditionReached(
                () => collabTitle.WaitDisplayed(50), 2, 50,
                $"Ожидание появления названия коллабы '{name}' в чате");

            return isNameDisplayed;
        }

        /// <summary>
        /// Проверяет отображение сообщения с описанием коллабы
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool IsCollaborationDescriptionDisplayed(string description)
        {
            var collabText = new MobileElement($"//android.widget.TextView[@text='{description}']",
               $"Сообщение в чате коллабы с текстом '{description}'");

            bool isDescriptionDesplyed = WaitersCore.WaitForConditionReached(
                () => collabText.WaitDisplayed(50), 2, 50,
                $"Ожидание появления сообщения '{description}' в чате коллабы");

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
