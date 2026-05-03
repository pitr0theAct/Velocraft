using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.DevTools.V143.Emulation;
using OpenQA.Selenium.DevTools.V143.Page;
using OpenQA.Selenium.DevTools.V144.DOM;

namespace Demo.PageObjects
{
    /// <summary>
    /// Основная страница сайта Velocraft
    /// </summary>
    public class VelocraftHomePage
    {
        #region Elements
        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "Кнопка 'Роботы'");
        WebItemWrap selectBase => new WebItemWrap("//div[contains(@class, 'content-catalog__header-group')]/child::p[text()='Основа']", "Кнопка Основа");

        WebItemWrap selectForkCategory => new WebItemWrap("//div[@class='content-catalog__category-item']/child::p[text()='Вилка']", "Кнопка Вилка");

        WebItemWrap selectFrame(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[@alt='{name}']", "Рама в списке");

        WebItemWrap buttonAdd => new WebItemWrap("//button[contains(@class,'button_add')]", "Кпока Добавить в сборку");

        WebItemWrap frameInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Рама {name} в блоке сборки");

        WebItemWrap forkInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Вилка {name} в блоке сборки");

        WebItemWrap weelsInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Колеса {name} в блоке сборки");

        WebItemWrap tiresInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Покрышки {name} в блоке сборки");

        WebItemWrap confirmButton => new WebItemWrap("//button[@class='ui-btn popup__button --danger']", "Кнопка подтвердить изменение");

        WebItemWrap selectFork(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Вилка в списке");

        WebItemWrap selectWeels(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Колеса в списке");

        WebItemWrap selectTires(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Покрышки в списке");

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
            return new VelocraftHomePage();
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
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Метод добавления вилки в сборку
        /// </summary>
        /// <param name="name">Название вилки</param>
        /// <returns></returns>
        public VelocraftHomePage AddFork(string name)
        {
            selectFork(name).WaitDisplayed(5);
            selectFork(name).Click();
            selectedSection.WaitDisplayed(5);
            buttonAdd.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Метод добавления колес в сборку
        /// </summary>
        /// <param name="name">Название колес</param>
        /// <returns></returns>
        public VelocraftHomePage AddWeels(string name)
        {
            selectWeels(name).WaitDisplayed(5);
            selectWeels(name).Click();
            selectedSection.WaitDisplayed(5);
            buttonAdd.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Метод добавления покрышек в сборку
        /// </summary>
        /// <param name="name">Название покрышек</param>
        /// <returns></returns>
        public VelocraftHomePage AddTires(string name)
        {
            selectTires(name).Click();
            buttonAdd.Click();
            selectTires(name).Click();
            selectedSection.WaitDisplayed(5);
            buttonAdd.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Подтверждение изменения рамы
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage ConfirmFrameChange()
        {
            confirmButton.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Проверка соответсвия названия рамы
        /// </summary>
        /// <param name="name">Название рамы</param>
        /// <returns></returns>
        public bool AssertFrameName(string name)
        {
            bool isFrameNameExists = frameInCraft(name).WaitDisplayed(50);
            return isFrameNameExists;
        }

        /// <summary>
        /// Проверка отсутсвия рамы сборке
        /// </summary>
        /// <param name="name">Название рамы</param>
        /// <returns></returns>
        public bool HaveNoFrame(string name)
        {
            bool isElementsNotInCraft = frameInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }

        /// <summary>
        /// Проверка отсутсвия вилки в сборке
        /// </summary>
        /// <param name="name">Название вилки</param>
        /// <returns></returns>
        public bool HaveNoFork(string name)
        {
            bool isElementsNotInCraft = forkInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }

        /// <summary>
        /// Проверка отсутсвия колес в сборке
        /// </summary>
        /// <param name="name">Название колес</param>
        /// <returns></returns>
        public bool HaveNoWeels(string name)
        {
            bool isElementsNotInCraft = weelsInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }

        /// <summary>
        /// Проверка отсутсвия покрышек в сборке
        /// </summary>
        /// <param name="name">Название покрышек</param>
        /// <returns></returns>
        public bool HaveNoTires(string name)
        {
            bool isElementsNotInCraft = tiresInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }

        /// <summary>
        /// Открыть категорию основа
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage OpenBase()
        {
            selectBase.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Открыть категорию вилка
        /// </summary>
        /// <returns></returns>
        public VelocraftHomePage OpenFork()
        {
            selectForkCategory.Click();
            return new VelocraftHomePage();
        }

        /// <summary>
        /// Проверка того, что каталог пуст
        /// </summary>
        /// <returns></returns>
        public bool AssertEmptyCatalog()
        {
            bool isCatalogEmpty = emptyCatalog.WaitDisplayed(3);
            return isCatalogEmpty;
        }

        public bool AssertFrameBrand(string brandName)
        {
            bool isBrandExist = new WebItemWrap($"//section[@class='content-catalog__catalog-container --build']//descendant::div[@class='catalog-item__manufacturer']/child::p[text()='{brandName}']", 
                "Название бренда детали в блоке Просмотр сборки").AssertTextContaining(brandName, "Название бренда детали не корректное");
            return isBrandExist;
        }
    }
}
