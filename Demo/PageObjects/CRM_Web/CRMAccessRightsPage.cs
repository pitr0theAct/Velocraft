using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Страница прав доступа CRM
    /// </summary>
    public class CRMAccessRightsPage
    {
        #region Elements
        WebItemWrap addRightsButton => new WebItemWrap("//a[@name='crmUserSelect']", "Кнопка 'Добавить право доступа'");
        WebItemWrap saveButton => new WebItemWrap("//button[@type='submit']", "Кнопка сохранить");
        #endregion

        public CRMAccessRightsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Открыть настройку прав
        /// </summary>
        /// <returns></returns>
        public RightsManagingPage OpenRightsManagingPage()
        {
            addRightsButton.Click();
            return new RightsManagingPage();
        }

        /// <summary>
        /// Сохранить измененения прав
        /// </summary>
        /// <returns></returns>
        public CRMAccessRightsPage SaveUserRights()
        {
            saveButton.Click();
            return new CRMAccessRightsPage();
        }
    }
}
