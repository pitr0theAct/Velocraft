using Demo.SeleniumFramework;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects.CRM_Web
{
    /// <summary>
    /// Страница создания робота
    /// </summary>
    public class RobotCreationPage
    {
        #region Elements
        WebItemWrap deadDeadLine => new WebItemWrap("//input[@name='deadline']", "Поле для выбора дедлайна дела");
        WebItemWrap currentTimeOption => new WebItemWrap("//label[@class='bizproc-automation-popup-select__wrapper --first ui-ctl ui-ctl-radio ui-ctl-w100']",
            "Опция Текущее время");
        WebItemWrap confurmTimeOption => new WebItemWrap("//button[@class='ui-btn ui-btn-primary']/child::span", "Кнопка выбрать");
        WebItemWrap dealNameTextField => new WebItemWrap("//input[@value='Связаться с клиентом']", "Поля для вода названия дела");
        WebItemWrap addDealResponsible => new WebItemWrap("//span[@class='ui-tag-selector-item ui-tag-selector-add-button']",
            "Поле для дбавления ответсвенного");
        WebItemWrap selectResoponsible(User responsible) => new WebItemWrap($"//div[@class= 'ui-selector-item-title' and text()='{responsible.NameLastName}']",
            "Ответсвенный");
        WebItemWrap saveRobotSettings => new WebItemWrap("//div[@class='popup-window-buttons']/child::button[@class='ui-btn ui-btn-success']",
            "Кнопка сохранить");
        #endregion

        public RobotCreationPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Заполнитьь форму создания робота
        /// </summary>
        /// <param name="dealName"></param>
        /// <param name="responsible"></param>
        /// <returns></returns>
        public RobotPage FillRobotCreationForm(string dealName, User responsible)
        {
            deadDeadLine.Click();
            currentTimeOption.WaitDisplayed(50);
            currentTimeOption.Click();
            confurmTimeOption.Click();
            dealNameTextField.SendKeys(dealName);
            addDealResponsible.Click();
            selectResoponsible(responsible).Click();
            saveRobotSettings.Click();
            return new RobotPage();
        }
    }
}
