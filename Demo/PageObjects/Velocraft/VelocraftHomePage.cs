using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.DevTools.V143.Emulation;
using OpenQA.Selenium.DevTools.V143.Page;
using OpenQA.Selenium.DevTools.V144.DOM;
using Demo.BaseFramework.LogTools;

namespace Demo.PageObjects
{
    /// <summary>
    /// Основная страница сайта Velocraft
    /// </summary>
    public class VelocraftHomePage
    {
        #region Elements
        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "Кнопка закрытия попапа");
        WebItemWrap selectBase => new WebItemWrap("//div[contains(@class, 'content-catalog__header-group')]/child::p[text()='Основа']", "Кнопка Основа");

        WebItemWrap selectForkCategory => new WebItemWrap("//div[@class='content-catalog__category-item']/child::p[text()='Вилка']", "Кнопка Вилка");

        WebItemWrap selectFrame(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[@alt='{name}']", "Рама в списке");

        WebItemWrap buttonAdd => new WebItemWrap("//button[contains(@class,'button_add')]", "Кпока Добавить в сборку");

        WebItemWrap partInCraft(string name, string partType = "Деталь") => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"{partType} {name} в блоке сборки");

        WebItemWrap confirmButton => new WebItemWrap("//button[@class='ui-btn popup__button --danger']", "Кнопка подтвердить изменение");

        WebItemWrap selectPart(string name, string partType = "Деталь") => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", $"{partType} в списке");

        WebItemWrap emptyCatalog => new WebItemWrap("//div[@class='content-catalog__catalog-empty']", "Пустой катлог");

        WebItemWrap selectedSection => new WebItemWrap("//section[@class='content-info__item-image --active']", "Поле выбранной детали");

        #endregion Elements

        public IWebDriver Driver { get; }

        public VelocraftHomePage(IWebDriver driver = default)
        {   
            Driver = driver;
        }

        /// <summary>
        /// Метод закрытия попапа с вводом антропометрических данных
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage ClosePopUp()
        {
            if (closePopUpButton.WaitDisplayed(5, Driver))
            {
                closePopUpButton.Click(Driver);
            }
            return this;
        }

        /// <summary>
        /// Метод добавления рамы в сборку
        /// </summary>
        /// <param name="name">Название рамы</param>
        /// <returns></returns>
        public VelocraftHomePage AddFrame(string name)
        {
            selectBase.WaitDisplayed(5);
            selectBase.Click();
            selectFrame(name).ScrollIntoView(alignToTop: false);
            selectFrame(name).WaitDisplayed(5);
            selectFrame(name).Click();
            selectedSection.WaitDisplayed(5);
            buttonAdd.Click();
            return this;
        }

        /// <summary>
        /// Метод добавления детали в сборку
        /// </summary>
        /// <param name="name">Название детали</param>
        /// <param name="partType">Тип детали</param>
        /// <returns></returns>
        public VelocraftHomePage AddPart(string name, string partType = "Деталь")
        {
            var part = selectPart(name, partType);
            part.WaitDisplayed(5);
            part.Click();
            selectedSection.WaitDisplayed(5);
            buttonAdd.Click();
            return this;
        }

        /// <summary>
        /// Подтверждение изменения рамы
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage ConfirmFrameChange()
        {
            confirmButton.Click();
            return this;
        }

        /// <summary>
        /// Проверка соответсвия названия рамы
        /// </summary>
        /// <param name="name">Название рамы</param>
        /// <returns></returns>
        public VelocraftHomePage AssertFramePresent(string name)
        {
            bool isFrameNameExists = partInCraft(name, "Рама").WaitDisplayed(50);
            if (!isFrameNameExists)
            {
                Log.Error($"Название рамы {name} не отображается в блоке Просмотр сборки");
            }
            return this;
        }

        /// <summary>
        /// Проверка сброса старых деталей
        /// </summary>
        public VelocraftHomePage AssertPartsReset(string frameName, string forkName, string weelsName, string tiresName)
        {
            if (partInCraft(frameName, "Рама").WaitDisplayed())
            {
                Log.Error($"Рама {frameName} не сбросилась из блока Просмотр сборки");
            }
            if (partInCraft(forkName, "Вилка").WaitDisplayed())
            {
                Log.Error($"Вилка {forkName} не сбросилась из блока Просмотр сборки");
            }
            if (partInCraft(weelsName, "Колеса").WaitDisplayed())
            {
                Log.Error($"Колеса {weelsName} не сбросились из блока Просмотр сборки");
            }
            if (partInCraft(tiresName, "Покрышки").WaitDisplayed())
            {
                Log.Error($"Покрышки {tiresName} не сбросились из блока Просмотр сборки");
            }
            return this;
        }

        /// <summary>
        /// Открыть категорию основа
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage OpenBase()
        {
            selectBase.Click();
            return this;
        }

        /// <summary>
        /// Открыть категорию вилка
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage OpenFork()
        {
            selectForkCategory.Click();
            return this;
        }

        /// <summary>
        /// Проверка того, что каталог пуст
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage AssertCatalogEmpty(string errorMessage)
        {
            bool isCatalogEmpty = emptyCatalog.WaitDisplayed(3);
            if (!isCatalogEmpty)
            {
                Log.Error(errorMessage);
            }
            return this;
        }

        public VelocraftHomePage AssertCatalogNotEmpty(string errorMessage)
        {
            bool isCatalogEmpty = emptyCatalog.WaitDisplayed(3);
            if (isCatalogEmpty)
            {
                Log.Error(errorMessage);
            }
            return this;
        }

        public VelocraftHomePage AssertFrameBrand(string brandName)
        {
            bool isBrandExist = new WebItemWrap($"//section[@class='content-catalog__catalog-container --build']//descendant::div[@class='catalog-item__manufacturer']/child::p[text()='{brandName}']", 
                "Название бренда детали в блоке Просмотр сборки").AssertTextContaining(brandName, "Название бренда детали не корректное");
            return this;
        }
    }
}
