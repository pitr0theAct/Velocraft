using Demo.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Demo.PageObjects.CRM_Web
{
    public class CRMBasePage
    {
        WebItemWrap robotButton => new WebItemWrap("//a[contains(@class, 'crm-robot-btn')]", "Кнопка 'Роботы'");
        WebItemWrap robotFrame => new WebItemWrap("//iframe[@class='side-panel-iframe']", "Фрейм Роботы");
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

        public CRMBasePage ChangeDealStatus(string dealName)
        {
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
    }


}
