using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class WebHomePage
    {
        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "Кнопка 'Роботы'");

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
    }
}
