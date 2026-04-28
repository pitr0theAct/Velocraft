using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class TaskAdditionalActionsMenu
    {
        WebItemWrap accessRightsButton => new WebItemWrap("//div[@class='menu-popup-items']/child::span[@onclick]", "Кнопка Права доступа в попапе");

        public TaskAdditionalActionsMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public TaskPermissionsSidePanel OpenTaskPermissionsForm()
        {
            accessRightsButton.Click();
            return new TaskPermissionsSidePanel();
        }
    }
}  
