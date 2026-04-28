using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Страница Роботы
    /// </summary>
    public class RobotPage
    {
        #region Elements
        WebItemWrap addRobotInProcessStage => new WebItemWrap("//div[@data-role='add-button-container' and @data-status-id='EXECUTING']",
            "Кнопка плюс под В работе");
        WebItemWrap saveButton => new WebItemWrap("//button[@class='ui-btn ui-btn-success']", "Кнопка сохранить");
        WebItemWrap closeButton => new WebItemWrap("//div[@class='side-panel-label-icon side-panel-label-icon-close']",
            "Кнопка закрыть страницу");
        WebItemWrap deleteRobotButton(User user) => new WebItemWrap($"//a[contains(text(), '{user.NameLastName}')]" +
            $"/ancestor::div[contains(@class, 'bizproc-automation-robot')]" +
            $"//span[contains(@class, 'bizproc-automation-robot-btn-delete')]", "Кнопка удаления робота");
        #endregion

        public RobotPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Открывает страницу создания робота
        /// </summary>
        /// <returns></returns>
        public RobotActionPage OpenRobotCreationPage()
        {
            addRobotInProcessStage.Click();
            return new RobotActionPage();
        }

        /// <summary>
        /// Сохранить настройки робота
        /// </summary>
        /// <returns></returns>
        public RobotPage SaveRobotSettings()
        {
            saveButton.Click();
            return new RobotPage();
        }

        /// <summary>
        /// Закрить страницу Роботы
        /// </summary>
        /// <returns></returns>
        public CRMBasePage CloseRobotPage()
        {
            closeButton.SwitchToDefaultContent();
            closeButton.Click();
            return new CRMBasePage();
        }

        /// <summary>
        /// Удалить робота
        /// </summary>
        /// <param name="responsible"></param>
        /// <returns></returns>
        public RobotPage DeleteRobot(User responsible)
        {
            deleteRobotButton(responsible).Click();
            saveButton.Click();
            return new RobotPage();
        }
    }
}
