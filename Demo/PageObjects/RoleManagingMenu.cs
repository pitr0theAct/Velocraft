using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class RoleManagingMenu
    {
        WebItemWrap roleTester(User user) => new WebItemWrap($"//div[text()='{user.NameLastName}']",
            "Пользователь созданны для проверки роли");
        WebItemWrap closeButton => new WebItemWrap("//span[@class='popup-window-close-icon']", "Кнопка Закрыть в окне попапа");
        WebItemWrap searchButton => new WebItemWrap("//a[@data-code='search']", "Кнопка Поиск");
        WebItemWrap searchTextField => new WebItemWrap("//input[@class='feed-add-destination-inp']", "Поле для поиска сотрудников");

        public TaskPermissionsSidePanel AddRoleToUser(User user)
        {
            searchButton.Click();
            searchTextField.SendKeys(user.Name);
            roleTester(user).WaitDisplayed(50);
            roleTester(user).Click();
            closeButton.Click();
            return new TaskPermissionsSidePanel();
        }

        public RoleManagingMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }



    }
}
