using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    public class CRMAccessRightsPage
    {
        WebItemWrap addRightsButton => new WebItemWrap("//a[@name='crmUserSelect']", "Кнопка 'Добавить право доступа'");
        WebItemWrap saveButton => new WebItemWrap("//button[@type='submit']", "Кнопка сохранить");

        public CRMAccessRightsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public RightsManagingPage OpenRightsManagingPage()
        {
            addRightsButton.Click();
            return new RightsManagingPage();
        }

        public CRMAccessRightsPage SaveUserRights()
        {
            saveButton.Click();
            return new CRMAccessRightsPage();
        }
    }
}
