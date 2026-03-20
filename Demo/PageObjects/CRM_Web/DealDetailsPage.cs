using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    public class DealDetailsPage
    {
        WebItemWrap hintPopUp => new WebItemWrap("//div[@class='ui-tour-popup  ui-tour-popup-events']", "Попап с подсказкой на странице дела");
        WebItemWrap closeHintButton => new WebItemWrap("//span[@class='popup-window-close-icon']", "Кнопка закрть в попапе");
        WebItemWrap doneButton(User user) => new WebItemWrap($"",
            "Кнопка выполнено в деле созданном робатом");

        public DealDetailsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public DealDetailsPage CloseHintIfDisplayed()
        {
            if (hintPopUp.WaitDisplayed(5, Driver))
            {
                closeHintButton.Click(Driver);
            }
            return new DealDetailsPage(Driver);
        }

        public bool AssertRobotDeal(string robotDealName)
        {
            bool isRobotDealExist = new WebItemWrap($"//span[contains(@title, '{robotDealName}') and @class='crm-timeline__card-title']", "Название дела созданного роботом")
                .AssertTextContaining(robotDealName, "Название дела созданного роботом некорректное", Driver);
            return isRobotDealExist;
        }

        public bool AssertResposible(User testResponsible)
        {
            CloseHintIfDisplayed();
            WebItemWrap responsibleIcon = new WebItemWrap($"//a[contains(@title,'{testResponsible.NameLastName}')]", "Имя ответсвенного за дело созданное роботом");
            bool isRosponsibleDisplyed = responsibleIcon.WaitDisplayed(50, Driver);
            return isRosponsibleDisplyed;
        }
    }
}
