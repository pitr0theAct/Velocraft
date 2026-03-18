using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class B24TasksListPage
    {
        WebItemWrap additionalActionsButton => new WebItemWrap("//div[@id='tasks_panel_menu_more_button']/child::span", "Кнопка 'Еще' в основном меню задач");

        public B24TasksListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public TaskAdditionalActionsMenu ExpandMoreOptions()
        {
            additionalActionsButton.Hover();
            return new TaskAdditionalActionsMenu();
        }
    }
}