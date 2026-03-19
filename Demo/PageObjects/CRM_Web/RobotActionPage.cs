using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    public class RobotActionPage
    {
        WebItemWrap openSearchButton => new WebItemWrap("//a[@class='ui-ctl-after ui-ctl-icon-search']", "Кнопка чтобы открыть поле поиска");
        WebItemWrap robotActionSearch => new WebItemWrap("//input[@class='ui-ctl-element ui-ctl-textbox']", "Поле для поиска");
        WebItemWrap addActionButton => new WebItemWrap("//div[@class='ui-entity-catalog__option']/child::div[@class='ui-entity-catalog__option-btn-block']",
            "Кнопка добавить");

        public RobotActionPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

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
