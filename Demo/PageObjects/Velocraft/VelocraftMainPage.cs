using Demo.SeleniumFramework;
using OpenQA.Selenium;
using System.Xml.Linq;
using Demo.BaseFramework.LogTools;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Главная страница сайта "Velocraft"
    /// Содержит методы для ввода антропометрических данных, перехода к авторизации,
    /// открытия категории «Основа», сохранения сборки и проверки отображения выбранных деталей в блоке «Просмотр сборки».
    /// </summary>
    public class VelocraftMainPage
    {
        public IWebDriver Driver { get; }

        public VelocraftMainPage(IWebDriver driver = default)
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

        WebItemWrap ChangeAccountButton =>
            new WebItemWrap("//button[contains(@class, 'button_login') and normalize-space()='Войти']",
                "Кнопка 'Войти'");

        /// <summary>
        /// Вводит рост (180 см) и вес (80 кг) в соответствующие поля всплывающего окна и нажимает кнопку «Сохранить».
        /// </summary>
        /// <returns>Новый экземпляр главной страницы <see cref="VelocraftMainPage"/> с сохранённым драйвером/></returns>
        public VelocraftMainPage EnteringHeightAndWeight()
        {
            InputHeightField.SendKeys("180");
            InputWeightField.SendKeys("80");
            SavePopupButton.Click();
            return new VelocraftMainPage(this.Driver);
        }

        /// <summary>
        /// Выполняет переход на страницу авторизации с главной страницы путём нажатия кнопки «Войти».
        /// </summary>
        /// <returns>Страница авторизации <see cref="VelocraftLoginPage"/></returns>
        public VelocraftLoginPage GoToAuthorizationPage()
        {
            ChangeAccountButton.Click();
            return new VelocraftLoginPage();
        }


        /// <summary>
        /// Открывает категорию сборки «Основа» для выбора рамы и вилки.
        /// </summary>
        /// <returns>Страница выбора деталей из категории "Основа" <see cref="VelocraftBasePage"/></returns>
        public VelocraftBasePage OpenBase()
        {
            BaseButton.Click();
            return new VelocraftBasePage();
        }

        /// <summary>
        /// Сохраняет текущую сборку (примечание: функционал сохранения пока не реализован).
        /// </summary>
        /// <returns>Новый экземпляр главной страницы <see cref="VelocraftMainPage"/></returns>
        public VelocraftMainPage SavingBuild()
        {
            SaveBuildButton.WaitDisplayed(5);
            SaveBuildButton.Click();
            return new VelocraftMainPage(this.Driver);
        }

        /// <summary>
        /// Проверяет, что выбранная рама отображается в блоке «Просмотр сборки».
        /// </summary>
        /// <param name="frameName">Название рамы (значение атрибута alt)</param>
        /// <returns>Новый экземпляр главной страницы <see cref="VelocraftMainPage"/></returns>
        /// <exception cref="Exception">Выбрасывается, если рама не найдена в блоке сборки</exception>
        public VelocraftMainPage AssertFrameInViewBuild(string frameName)
        {
            var frameInBuild = new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container') and contains(@class, '--build')]//img[@alt='{frameName}']", 
                $"Рама {frameName} в блоке сборки");
            if (!frameInBuild.WaitDisplayed())
            {
                throw new Exception($"Рама '{frameName}' не отображается в блоке сборки");
            }
            Log.Info($"Рама '{frameName}' успешно добавлена в сборку и отображается в блоке сборки");
            return new VelocraftMainPage();
        }

        /// <summary>
        /// Проверяет, что выбранная вилка отображается в блоке «Просмотр сборки».
        /// </summary>
        /// <param name="forkName">Название вилки (уникальная часть атрибута alt)</param>
        /// <returns>Новый экземпляр главной страницы <see cref="VelocraftMainPage"/></returns>
        /// <exception cref="Exception">Выбрасывается, если вилка не найдена в блоке сборки</exception>
        public VelocraftMainPage AssertForkInViewBuild(string forkName)
        {
            var forkInBuild = new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container') and contains(@class, '--build')]//img[contains(@alt, '{forkName}')]",
                $"Вилка {forkName} в блоке сборки");
            if (!forkInBuild.WaitDisplayed())
            {
                throw new Exception($"Вилка '{forkName}' не отображается в блоке сборки");
            }
            Log.Info($"Вилка '{forkName}' успешно добавлена в сборку и отображается в блоке сборки");
            return new VelocraftMainPage();
        }

        /// <summary>
        /// Проверяет, что последняя необходимая деталь - седло отображается в блоке «Просмотр сборки».
        /// </summary>
        /// <param name="saddleName">Название седла (значение атрибута alt)</param>
        /// <returns>Новый экземпляр главной страницы <see cref="VelocraftMainPage"/></returns>
        /// <exception cref="Exception">Выбрасывается, если седло не найдено в блоке сборки</exception>
        public VelocraftMainPage AssertSaddleInViewBuild(string saddleName)
        {
            var saddleInBuild = new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container') and contains(@class, '--build')]//img[contains(@alt, '{saddleName}')]",
                $"Седло {saddleName} в блоке сборки");
            saddleInBuild.ScrollIntoView(alignToTop: false);
            if (!saddleInBuild.WaitDisplayed())
            {
                throw new Exception($"Седло '{saddleName}' не отображается в блоке сборки");
            }
            Log.Info($"Седло '{saddleName}' успешно добавлено в сборку и отображается в блоке сборки");
            return new VelocraftMainPage();
        }
    }
}
