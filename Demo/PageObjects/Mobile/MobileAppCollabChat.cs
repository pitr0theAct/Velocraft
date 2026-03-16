
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
            var collabTitle = new MobileElement($"//android.widget.TextView[contains(@content-desc,'{name.Substring(0,22)}')]",
                $"Заголовок коллабы с текстом {name}");

            bool isNameDisplayed = WaitersCore.WaitForConditionReached(
                () => collabTitle.WaitDisplayed(50), 2, 50,
                $"Ожидание появления коллабы '{name}' в верхней части");

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
    }
}
