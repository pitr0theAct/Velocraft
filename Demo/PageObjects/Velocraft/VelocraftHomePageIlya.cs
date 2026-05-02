using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects.Velocraft
{
    public class VelocraftHomePageIlya
    {
        public IWebDriver Driver { get; }

        public VelocraftHomePageIlya(IWebDriver driver = default)
        {
            Driver = driver;
        }

        WebItemWrap InputHeightField => 
            new WebItemWrap("//input[@id='rider_height']", 
                "Поле для ввода роста");

        WebItemWrap InputWeightField => 
            new WebItemWrap("//input[@id='rider_weight']", 
                "Поле для ввода веса");

        WebItemWrap SavePopupButton => 
            new WebItemWrap("//button[contains(@class, 'popup__button') and .//span[text()='Сохранить']]", 
                "Поле для ввода веса");

        WebItemWrap BaseButton =>
             new WebItemWrap("//div[contains(@class, 'content-catalog__header-group') and .//p[text()='Основа']]",
                "Кнопка Основа в верхнем меню");

        WebItemWrap SaveBuildButton =>
             new WebItemWrap("//button[contains(@class, 'button_save') and normalize-space()='Сохранить сборку']",
                "Кнопка 'Сохранить сборку'");


        public VelocraftHomePageIlya EnteringHeightAndWeight()
        {
            InputHeightField.SendKeys("180");
            InputWeightField.SendKeys("80");
            SavePopupButton.Click();
            return new VelocraftHomePageIlya(this.Driver);
        }

        public VelocraftBasePage OpenBase()
        {
            BaseButton.Click();
            return new VelocraftBasePage();
        }

        public VelocraftHomePageIlya SavingBuild()
        {
            SaveBuildButton.WaitDisplayed(5);
            SaveBuildButton.Click();
            return new VelocraftHomePageIlya(this.Driver);
        }
    }
}
