using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Детальная страница сделки в CRM
    /// </summary>
    public class DealDetailsPage
    {
        #region Elements
        WebItemWrap hintPopUp => new WebItemWrap("//div[@class='ui-tour-popup  ui-tour-popup-events']", "Попап с подсказкой на странице дела");
        WebItemWrap closeHintButton => new WebItemWrap("//span[@class='popup-window-close-icon']", "Кнопка закрть в попапе");
        WebItemWrap robotCreatedDealName(string name) => new WebItemWrap($"//span[contains(@title, '{name}') and @class='crm-timeline__card-title']",
            "Название дела созданного роботом");
        WebItemWrap responsibleIcon(User user) => new WebItemWrap($"//a[contains(@title,'{user.NameLastName}')]", "Имя ответсвенного за дело созданное роботом");
        #endregion

        public DealDetailsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Закрыть подсказку, если она есть
        /// </summary>
        /// <returns></returns>
        public DealDetailsPage CloseHintIfDisplayed()
        {
            if (hintPopUp.WaitDisplayed(5, Driver))
            {
                closeHintButton.Click(Driver);
            }
            return new DealDetailsPage(Driver);
        }

        /// <summary>
        /// Проверка наличия дела созданного роботом
        /// </summary>
        /// <param name="robotDealName"></param>
        /// <returns></returns>
        public bool AssertRobotDeal(string robotDealName)
        {
            bool isRobotDealExist = robotCreatedDealName(robotDealName).AssertTextContaining(robotDealName, "Название дела созданного роботом некорректное", Driver);
            return isRobotDealExist;
        }

        /// <summary>
        /// Проверка пользователя которому робот поручил дело
        /// </summary>
        /// <param name="testResponsible"></param>
        /// <returns></returns>
        public bool AssertResposible(User testResponsible)
        {
            CloseHintIfDisplayed();
            bool isRosponsibleDisplyed = responsibleIcon(testResponsible).WaitDisplayed(50, Driver);
            return isRosponsibleDisplyed;
        }
    }
}
