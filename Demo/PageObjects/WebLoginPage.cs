using Demo.SeleniumFramework;
using Demo.SeleniumFramework.DriverActions;
using Demo.TestEntities;
using OpenQA.Selenium;

namespace Demo.PageObjects
{
    class WebLoginPage : LoginPageBase
    {
        IWebDriver Driver { get; }

        WebItemWrap loginButton => new WebItemWrap("//button[@class='button_login']", "Кнопка Войти на главной странице");

        WebItemWrap closePopUpButton => new WebItemWrap("//span[@class='popup-window-close-icon popup-window-titlebar-close-icon']", "нопка закрытия попапа");

        WebItemWrap submitButton => new WebItemWrap("//button[@class='login__submit-button']", "Кнопка войти на странице входа");

        public WebLoginPage(PortalData portal, IWebDriver driver = default) : base(portal)
        {
            Driver = driver;
        }

        public WebHomePage Login(User admin)
        {
            DriverActionsWeb.OpenUri(portalData.Adress, Driver);
            /*var loginField = new WebItemWrap("//input[@id='login' or @name='USER_LOGIN']",
                "Поле для ввода логина");
            var pwdField = new WebItemWrap("//input[@id='password' or @name='USER_PASSWORD']",
                "Поле для ввода пароля");
            loginField.SendKeys(admin.Login, Driver);
            if (!pwdField.WaitDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(admin.Password, Driver, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter, Driver);*/
            return new WebHomePage(Driver);
        }

        public VelocraftHomePage LoginVelocraft(User admin)
        {
            DriverActionsWeb.OpenUri(portalData.Adress, Driver);
            if (closePopUpButton.WaitDisplayed(5, Driver))
            {
                closePopUpButton.Click(Driver);
            }
            loginButton.Click(); 
            var loginField = new WebItemWrap("//input[@class='login__input' and @type='text']",
                "Поле для ввода логина");
            var pwdField = new WebItemWrap("//input[@class='login__input' and @type='password']",
                "Поле для ввода пароля");
            loginField.SendKeys(admin.Login, Driver);
            if (!pwdField.WaitDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(admin.Password, Driver, logInputtedText: false);
            submitButton.Click();
            
            return new VelocraftHomePage(Driver);
        }
    }
}