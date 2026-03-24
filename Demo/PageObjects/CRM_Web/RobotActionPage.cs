using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Страница выбора действия робота
    /// </summary>
    public class RobotActionPage
    {
        #region Elements
        WebItemWrap openSearchButton => new WebItemWrap("//a[@class='ui-ctl-after ui-ctl-icon-search']", "Кнопка чтобы открыть поле поиска");
        WebItemWrap robotActionSearch => new WebItemWrap("//input[@class='ui-ctl-element ui-ctl-textbox']", "Поле для поиска");
        WebItemWrap addActionButton => new WebItemWrap("//div[@class='ui-entity-catalog__option']/child::div[@class='ui-entity-catalog__option-btn-block']",
            "Кнопка добавить");
        #endregion

        public RobotActionPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Выбрать метод робота Запланировать дело
        /// </summary>
        /// <returns></returns>
        public RobotCreationPage SelectRobotAction()
        {
            openSearchButton.Click();
            robotActionSearch.SendKeys("Запланировать дело");
            addActionButton.WaitDisplayed(50);
            addActionButton.Click();
            return new RobotCreationPage();
        }
    }
}
