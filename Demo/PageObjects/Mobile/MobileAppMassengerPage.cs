

using Demo.SeleniumFramework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Demo.PageObjects.Mobile
{
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
        //Недавний поиск нужно заменить
        MobileElement moderatorPerson => new MobileElement("//android.widget.LinearLayout[@content-desc='section_{Недавний поиск}']", "Пользователь которго мы выбираем модератором");
        MobileElement selectModeratorButton => new MobileElement("//android.widget.FrameLayout[@resource-id='com.bitrix24.android:id/apply_button']", 
            "Кнопка выбрать на странице выбора модератора");
        MobileElement inviteSettingsButton => new MobileElement("//android.view.ViewGroup[@content-desc='collab-create-security-area-permissions-list']" +
            "/android.view.ViewGroup/android.view.ViewGroup[3]",
            "Кнопка настройки прав приглашений");
        //Нужно поменать xpath
        MobileElement onlyOwnerButton => new MobileElement("//android.widget.FrameLayout[@content-desc='popup_menu']//android.view.ViewGroup[@content-desc='popover_menu_A']", 
            "Кнопка 'только владелец' в попапе");
        MobileElement backButton => new MobileElement("(//android.widget.FrameLayout[@content-desc='button_back'])[3]", "Кнопка назад");
        MobileElement createCollaboration => new MobileElement("//android.widget.TextView[@text='Создать коллабу']", "Кнопка создать коллаборацию");
        #endregion


        public MobileAppMassengerPage FillCollaborationForm(string collabName, string collabText)
        {
            //selectCollab.WaitDisplayed(50);
            selectCollab.Click();
            //continueButton.WaitDisplayed(50);
            continueButton.Click();
            //.WaitDisplayed(50);
            nameTextField.SendKeys(collabName); // Начиная с этого поля нужно менять локаторы
            descriptionTextField.WaitDisplayed(50);
            descriptionTextField.SendKeys(collabText);
            return new MobileAppMassengerPage();
        }

        public MobileAppMassengerPage OpenCreationMenu()
        {
            //createButton.WaitDisplayed(50);
            createButton.Click();
            return new MobileAppMassengerPage();
        }

        public MobileAppMassengerPage FillCollaborationSettings()
        {
            rightSettingButton.Click();
            moderatorButton.Click();
            moderatorPerson.Click();
            selectModeratorButton.Click();
            inviteSettingsButton.Click();
            onlyOwnerButton.WaitDisplayed(50);
            onlyOwnerButton.Click();
            return new MobileAppMassengerPage();
        }

        public MobileAppMassengerPage CreateCollaboration()
        {
            backButton.Click();
            createCollaboration.Click();
            return new MobileAppMassengerPage();
        }
    }
}
