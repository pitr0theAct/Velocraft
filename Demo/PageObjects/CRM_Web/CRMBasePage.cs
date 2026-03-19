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
            dealInCanban(dealName).Click();
            changeDealStateButton.Click();
            newDealState.WaitDisplayed(50);
            newDealState.Click();
            return new CRMBasePage();
        }
    }


}
