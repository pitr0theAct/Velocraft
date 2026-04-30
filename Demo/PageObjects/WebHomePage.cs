using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.DevTools.V143.Emulation;
using OpenQA.Selenium.DevTools.V143.Page;
using OpenQA.Selenium.DevTools.V144.DOM;

namespace Demo.PageObjects
{
    public class WebHomePage
    {
        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "Кнопка 'Роботы'");
        WebItemWrap selectBase => new WebItemWrap("//div[contains(@class, 'content-catalog__header-group')]/child::p[text()='Основа']", "Кнопка Основа");

        WebItemWrap selectFrame(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[@alt='{name}']", "Рама в списке");

        WebItemWrap buttonAdd => new WebItemWrap("//button[@class='button_add']", "Кпока Добавить в сборку");

        WebItemWrap frameInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Рама {name} в блоке сборки");

        WebItemWrap forkInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Вилка {name} в блоке сборки");

        WebItemWrap weelsInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Колеса {name} в блоке сборки");

        WebItemWrap tiresInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Покрышки {name} в блоке сборки");

        WebItemWrap confirmButton => new WebItemWrap("//button[@class='ui-btn popup__button --danger']", "Кнопка подтвердить изменение");

        WebItemWrap selectFork(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Вилка в списке");

        WebItemWrap selectWeels(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Колеса в списке");

        WebItemWrap selectTires(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[contains(@alt,'{name}')]", "Покрышки в списке");

        public IWebDriver Driver { get; }

        public WebHomePage(IWebDriver driver = default)
        {   
            Driver = driver;
        }

        public SiteLeftMenu SideMenu => new SiteLeftMenu(Driver);

        public WebHomePage ClosePopUp()
        {
            if (closePopUpButton.WaitDisplayed(5, Driver))
            {
                closePopUpButton.Click(Driver);
            }
            return new WebHomePage();
        }

        public WebHomePage AddFrame(string name)
        {
            selectBase.Click();
            selectFrame(name).ScrollIntoView(alignToTop: false);
            selectFrame(name).Click();
            buttonAdd.Click();
            return new WebHomePage();
        }

        public WebHomePage AddFork(string name)
        {
            selectFork(name).Click();
            buttonAdd.Click();
            return new WebHomePage();
        }

        public WebHomePage AddWeels(string name)
        {
            selectWeels(name).Click();
            buttonAdd.Click();
            return new WebHomePage();
        }

        public WebHomePage AddTires(string name)
        {
            selectTires(name).Click();
            buttonAdd.Click();
            selectTires(name).Click();
            buttonAdd.Click();
            return new WebHomePage();
        }

        public WebHomePage ConfirmFrameChange()
        {
            confirmButton.Click();
            return new WebHomePage();
        }

        public bool AssertFrameName(string name)
        {
            bool isFrameNameExists = frameInCraft(name).WaitDisplayed(50);
            return isFrameNameExists;
        }

        public bool HaveNoFrame(string name)
        {
            bool isElementsNotInCraft = frameInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }

        public bool HaveNoFork(string name)
        {
            bool isElementsNotInCraft = forkInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }
        public bool HaveNoWeels(string name)
        {
            bool isElementsNotInCraft = weelsInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }
        public bool HaveNoTires(string name)
        {
            bool isElementsNotInCraft = tiresInCraft(name).WaitDisplayed();
            return isElementsNotInCraft;
        }
    }
}
