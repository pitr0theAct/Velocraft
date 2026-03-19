using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    public class RightsManagingPage
    {
        WebItemWrap usersButton => new WebItemWrap("//a[@class='access-provider-button' and contains(@onclick, 'user')]",
            "Кнопка пользователи");
        WebItemWrap userSearch => new WebItemWrap("//input[@class='bx-finder-box-search-textbox' and contains(@onkeyup,\"user\")]",
            "Поле для поиска пользователей");
        WebItemWrap foundUser(User user) => new WebItemWrap($"//div[@class='bx-finder-box-item-t2-text' and text()='{user.NameLastName}']",
            "Найденный пользователь в списке");
        WebItemWrap selectButton => new WebItemWrap("//span[@class='popup-window-button popup-window-button-accept']",
            "Кнопка выбрать");

        public RightsManagingPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

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
