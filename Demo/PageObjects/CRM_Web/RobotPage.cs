using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    public class RobotPage
    {
        WebItemWrap addRobotInProcessStage => new WebItemWrap("//div[@data-role='add-button-container' and @data-status-id='EXECUTING']",
            "Кнопка плюс под В работе");
        WebItemWrap saveButton => new WebItemWrap("//button[@class='ui-btn ui-btn-success']", "Кнопка сохранить");
        WebItemWrap closeButton => new WebItemWrap("//div[@class='side-panel-label-icon side-panel-label-icon-close']",
            "Кнопка закрыть страницу");
        WebItemWrap deleteRobotButton(User user) => new WebItemWrap($"//a[contains(text(), '{user.NameLastName}')]" +
            $"/ancestor::div[contains(@class, 'bizproc-automation-robot')]" +
            $"//span[contains(@class, 'bizproc-automation-robot-btn-delete')]", "Кнопка удаления робота");

        public RobotPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public RobotActionPage OpenRobotCreationPage()
        {
            addRobotInProcessStage.Click();
            return new RobotActionPage();
        }

        public RobotPage SaveRobotSettings()
        {
            saveButton.Click();
            return new RobotPage();
        }

        public CRMBasePage CloseRobotPage()
        {
            closeButton.SwitchToDefaultContent();
            closeButton.Click();
            return new CRMBasePage();
        }

        public RobotPage DeleteRobot(User responsible)
        {
            deleteRobotButton(responsible).Click();
            saveButton.Click();
            return new RobotPage();
        }
    }
}
