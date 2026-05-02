using Demo.SeleniumFramework;
using OpenQA.Selenium;
using System.Xml.Linq;
using Demo.BaseFramework.LogTools;

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
            new WebItemWrap("//button[contains(@class, 'popup__button')]//span[text()='Сохранить']", 
                "Кнопка 'Сохранить' рост и вес");

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

        public VelocraftHomePageIlya AssertFrameInViewBuild(string frameName)
        {
            var frameInBuild = new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container') and contains(@class, '--build')]//img[@alt='{frameName}']", 
                $"Рама {frameName} в блоке сборки");
            if (!frameInBuild.WaitDisplayed())
            {
                throw new Exception($"Рама '{frameName}' не отображается в блоке сборки");
            }
            Log.Info($"Рама '{frameName}' успешно добавлена в сборку и отображается в блоке сборки");
            return new VelocraftHomePageIlya();
        }

        public VelocraftHomePageIlya AssertForkInViewBuild(string forkName)
        {
            var forkInBuild = new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container') and contains(@class, '--build')]//img[contains(@alt, '{forkName}')]",
                $"Вилка {forkName} в блоке сборки");
            if (!forkInBuild.WaitDisplayed())
            {
                throw new Exception($"Рама '{forkName}' не отображается в блоке сборки");
            }
            Log.Info($"Вилка '{forkName}' успешно добавлена в сборку и отображается в блоке сборки");
            return new VelocraftHomePageIlya();
        }
    }
}
