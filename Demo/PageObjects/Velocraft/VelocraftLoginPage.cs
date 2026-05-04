using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Страница авторизации
    /// </summary>
    public class VelocraftLoginPage
    {
        // Авторизация
        WebItemWrap RegistrationButtonInLoginPage =>
            new WebItemWrap("//button[contains(@class, 'login__submit-button') and contains(@class, '--registration')]",
                "Кнопка 'Зарегистрироваться'");

        WebItemWrap AuthorizationButton =>
            new WebItemWrap("//button[contains(@class, 'login__submit-button') and normalize-space()='Войти']",
                "Кнопка 'Войти'");

        // Поле ввода логина 
        WebItemWrap LoginField => new WebItemWrap("//section[contains(@class, 'login-layout')]//input[@placeholder='Введите логин...']", 
            "Поле ввода логина");

        // Поле ввода пароля
        WebItemWrap PasswordField => new WebItemWrap("//section[contains(@class, 'login-layout')]//input[@placeholder='Введите пароль...']", 
            "Поле ввода пароля");

        /// <summary>
        /// Метод для перехода на страницу регистрации
        /// </summary>
        /// <returns>Страница регистрации</returns>
        public VelocraftRegistrationPage GoToRegistrationPage()
        {
            RegistrationButtonInLoginPage.Click();
            return new VelocraftRegistrationPage();
        }

        /// <summary>
        /// Выполняет авторизацию пользователя на сайте Velocraft
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Главная страница сайта</returns>
        public VelocraftMainPage Authorization(string login, string password)
        {
            LoginField.WaitDisplayed();
            LoginField.SendKeys(login);
            PasswordField.SendKeys(password);
            AuthorizationButton.Click();
            return new VelocraftMainPage();
        }
    }
}
