using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V143.Page;

namespace Demo.PageObjects
{
    public class WebHomePage
    {
        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "Кнопка 'Роботы'");
        WebItemWrap selectBase => new WebItemWrap("//div[contains(@class, 'content-catalog__header-group')]/child::p[text()='Основа']", "Кнопка Основа");

        WebItemWrap selectFrame(string name) => new WebItemWrap($"//div[@class='catalog-item__image']/child::img[@alt='{name}']", "Рама в списке");

        WebItemWrap buttonAdd => new WebItemWrap("//button[@class='button_add']", "Кпока Добавить в сборку");

        WebItemWrap frameInCraft(string name) => new WebItemWrap($"//section[@class='mainlayout__content-craft']/descendant::img[@alt='{name}']", $"Рама {name} в блоке сборки");

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
            selectFrame(name).Click();
            buttonAdd.Click();
            return new WebHomePage();
        }

        public bool AssertFrameName(string name)
        {
            bool isFrameNameExists = frameInCraft(name).WaitDisplayed(50);
            return isFrameNameExists;
        }
    }
}
