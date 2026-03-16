

using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;

namespace Demo.PageObjects.Mobile
{
    /// <summary>
    /// Страница мессенджера
    /// </summary>
    public class MobileAppMassengerPage
    {
        #region Elements
        MobileElement createButton => new MobileElement("//android.widget.ImageButton[@resource-id='com.bitrix24.android:id/component_fab']", "Кнопка плюс");
        MobileElement selectCollab => new MobileElement("//android.view.ViewGroup[@content-desc='create_collab']", "Кнопка коллаба");
        MobileElement continueButton => new MobileElement("//android.widget.TextView[@text='Продолжить']", "Кнопка продолжить");
        MobileElement nameTextField => new MobileElement("//android.widget.EditText[@content-desc='undefined-edit-name-input-placeholder']", "Поле для ввода названия");
        MobileElement descriptionTextField => new MobileElement("//android.widget.EditText[@content-desc='undefined-edit-description-textarea-placeholder']", "Поле для ввода описания");
        MobileElement rightSettingButton => new MobileElement("//android.view.ViewGroup[@content-desc='undefined-edit-area-settings']" +
            "/android.view.ViewGroup[1]/android.view.ViewGroup", "Кнопка 'Настройка прав'");
        MobileElement moderatorButton => new MobileElement("//android.view.ViewGroup[@content-desc='collab-create-security-area-permissions-list']" +
            "/android.view.ViewGroup/android.view.ViewGroup[2]",
            "Кнопка 'Модераторы'");
        MobileElement selectModeratorButton => new MobileElement("//android.widget.FrameLayout[@resource-id='com.bitrix24.android:id/apply_button']", 
            "Кнопка выбрать на странице выбора модератора");
        MobileElement inviteSettingsButton => new MobileElement("//android.view.ViewGroup[@content-desc='collab-create-security-area-permissions-list']" +
            "/android.view.ViewGroup/android.view.ViewGroup[3]",
            "Кнопка настройки прав приглашений");
        
        MobileElement onlyOwnerButton => new MobileElement("//android.widget.TextView[@content-desc=\"popover-menu-A-title\"]//ancestor::android.view.ViewGroup", 
            "Кнопка 'только владелец' в попапе");
        MobileElement backButton => new MobileElement("(//android.widget.FrameLayout[@content-desc='button_back'])[3]", "Кнопка назад");
        
        MobileElement createCollaboration => new MobileElement("//android.view.ViewGroup[@content-desc=\"CollabCreate_IntroScreen_Button\"]", "Кнопка создать коллаборацию");
        #endregion

        /// <summary>
        /// Переход в создание коллаборации; заполнение названия и описания
        /// </summary>
        /// <param name="collab"></param>
        /// <returns></returns>
        public MobileAppMassengerPage FillCollaborationForm(B24CollaborationEntity collab)
        {
            selectCollab.Click();
            continueButton.Click();
            nameTextField.SendKeys(collab.Name);
            descriptionTextField.SendKeys(collab.Description);
            return new MobileAppMassengerPage();
        }

        /// <summary>
        /// Нажатие на кнопку 'плюс'
        /// </summary>
        /// <returns></returns>
        public MobileAppMassengerPage OpenCreationMenu()
        {
            createButton.Click();
            return new MobileAppMassengerPage();
        }

        /// <summary>
        /// Заполняем настройки коллаборации: выбираем модератора и отключаем возможность приглашения гостей
        /// </summary>
        /// <param name="testModerator"></param>
        /// <returns></returns>
        public MobileAppMassengerPage FillCollaborationSettings(User testModerator)
        {
            var moderatorPerson = new MobileElement($"//android.widget.TextView[contains(@content-desc,'{testModerator.Name}')]/parent::android.widget.LinearLayout", 
                "Пользователь которго мы выбираем модератором");

            rightSettingButton.Click();
            moderatorButton.Click();
            moderatorPerson.Click();
            selectModeratorButton.Click();
            inviteSettingsButton.Click();
            onlyOwnerButton.Click();
            return new MobileAppMassengerPage();
        }

        /// <summary>
        /// Нажимаем на кнопку 'Создать коллаборацию'
        /// </summary>
        /// <returns></returns>
        public MobileAppCollabChat CreateCollaboration()
        {
            backButton.Click();
            createCollaboration.Click();
            return new MobileAppCollabChat();
        }
    }
}
