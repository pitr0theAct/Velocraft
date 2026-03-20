using Demo.SeleniumFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Demo.PageObjects.CRM_Web
{
    public class CRMBasePage
    {
        WebItemWrap robotButton => new WebItemWrap("//a[contains(@class, 'crm-robot-btn')]", "Кнопка 'Роботы'");
        WebItemWrap robotFrame => new WebItemWrap("//iframe[@class='side-panel-iframe']", "Фрейм Роботы"); // Поменять  xpath
        WebItemWrap dealInCanban(string dealName) => new WebItemWrap($"//span[text()='{dealName}']/ancestor::div[@class='main-kanban-item']", 
            "Сделка на странице CRM");
        WebItemWrap changeDealStateButton => new WebItemWrap($"//span[text()='Сменить стадию']", "Кнопка сменить стадию");
        WebItemWrap newDealState => new WebItemWrap("//span[@class='menu-popup-item-text' and text()='В работе']",
            "Кнопка подготовка документов в попапе");
        WebItemWrap settingsMainButton => new WebItemWrap("//span[text()='Настройки' and @class = 'main-buttons-item-text-box']",
            "Кнопка настроек в основном менб CRM");
        WebItemWrap accessRightsButton => new WebItemWrap("//span[text()='Права доступа' and @class = 'main-buttons-item-text-box']",
            "Кнопка Права доступа в попапе");
        WebItemWrap crmButton => new WebItemWrap("//span[@class='main-buttons-item-text-box' and text()='CRM']", "Кнопка CRM в попапе");
        WebItemWrap dealNameInCanban(string dealName) => new WebItemWrap($"//span[text()='{dealName}']/parent::a", "Название дела на странице CRM");
        WebItemWrap dealDetailsFrame => new WebItemWrap("//iframe[@class='side-panel-iframe' and contains(@src, 'deal/details')]",
            "Фрейм с детальной информацией о деле");

        WebItemWrap hintPopUp => new WebItemWrap("//div[@class='ui-tour-popup  ui-tour-popup-events']", "Попап с подсказкой");
        WebItemWrap closeHintButton => new WebItemWrap("//span[@class='popup-window-close-icon']", "Кнопка закрыть попап");

        public CRMBasePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public RobotPage OpenRobotPage()
        {
            robotButton.Click();
            robotFrame.SwitchToFrame();
            return new RobotPage();
        }

        public CRMBasePage CloseHintIfDisplayed()
        {
            if (hintPopUp.WaitDisplayed(5, Driver))
            {
                closeHintButton.Click(Driver);
            }
            return new CRMBasePage(Driver);
        }

        public CRMBasePage ChangeDealStatus(string dealName)
        {
            CloseHintIfDisplayed();
            dealInCanban(dealName).WaitDisplayed(50);
            dealInCanban(dealName).Click();
            changeDealStateButton.Click();
            newDealState.WaitDisplayed(50);
            newDealState.Click();
            return new CRMBasePage();
        }

        public CRMAccessRightsPage OpenCRMAccessRights()
        {
            settingsMainButton.Hover();
            accessRightsButton.Hover();
            accessRightsButton.Click();
            crmButton.Hover();
            crmButton.Click();
            return new CRMAccessRightsPage();
        }

        public DealDetailsPage OpenDealDetails(string dealName)
        {
            dealNameInCanban(dealName).WaitDisplayed(50, Driver);
            dealNameInCanban(dealName).Click(Driver);
            dealDetailsFrame.WaitDisplayed(50, Driver);
            dealDetailsFrame.SwitchToFrame(Driver);
            return new DealDetailsPage(Driver);
        }
    }


}
