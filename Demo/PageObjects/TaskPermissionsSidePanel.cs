using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class TaskPermissionsSidePanel
    {
        WebItemWrap taskPermissionsFrame => new WebItemWrap("//iframe[@class='side-panel-iframe']", "Фрейм котрый содержет настройки ролей");
        WebItemWrap createNewRole => new WebItemWrap("//div[text()='Создать роль']", "Кнопка 'Создать новую роль'");

        WebItemWrap roleNameTextField => new WebItemWrap("//div[contains(@class,'rights-role-edit')]/child::input[@class='ui-access-rights-role-input']",
            "Поле для ввода названия роли");
        WebItemWrap saveButton => new WebItemWrap("//button[@class='ui-btn ui-btn-success']", "Кнопка сохранить");

        WebItemWrap addRoleButton(string roleName) => new WebItemWrap($"//div[contains(@class, \"ui-access-rights-column\") and .//*[text()=\"{roleName}\"]]//span[contains(@class, \"ui-access-rights-members-item-add\")]", "Кнопка добавления пользователя в роль");

        public TaskPermissionsSidePanel(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public TaskPermissionsSidePanel CreateNewRole()
        {
            taskPermissionsFrame.SwitchToFrame();
            createNewRole.Click();
            return new TaskPermissionsSidePanel();
        }

        public TaskPermissionsSidePanel FillRoleName(string roleName)
        {
            roleNameTextField.SendKeys(roleName);
            return new TaskPermissionsSidePanel();
        }

        public TaskPermissionsSidePanel SaveRole()
        {
            saveButton.Click();
            return new TaskPermissionsSidePanel();
        }

        public RoleManagingMenu OpenRoleManagingMenu(string roleName)
        {
            addRoleButton(roleName).Click();
            return new RoleManagingMenu();
        }

        public TaskPermissionsSidePanel SelectRolePermissions()
        {
            return new TaskPermissionsSidePanel();
        }
    }
}
