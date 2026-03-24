using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Страница настройки прав доступа CRM
    /// </summary>
    public class RightsManagingPage
    {
        #region Elements
        WebItemWrap usersButton => new WebItemWrap("//a[@class='access-provider-button' and contains(@onclick, 'user')]",
            "Кнопка пользователи");
        WebItemWrap userSearch => new WebItemWrap("//input[@class='bx-finder-box-search-textbox' and contains(@onkeyup,\"user\")]",
            "Поле для поиска пользователей");
        WebItemWrap foundUser(User user) => new WebItemWrap($"//div[@class='bx-finder-box-item-t2-text' and text()='{user.NameLastName}']",
            "Найденный пользователь в списке");
        WebItemWrap selectButton => new WebItemWrap("//span[@class='popup-window-button popup-window-button-accept']",
            "Кнопка выбрать");
        #endregion

        public RightsManagingPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Добавить пользователю права
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
         public CRMAccessRightsPage AddUserRights(User user)
        {
            usersButton.Click();
            userSearch.SendKeys(user.NameLastName);
            foundUser(user).WaitDisplayed(50);
            foundUser(user).Click();
            selectButton.Click();
            return new CRMAccessRightsPage();
        }
    }
}
