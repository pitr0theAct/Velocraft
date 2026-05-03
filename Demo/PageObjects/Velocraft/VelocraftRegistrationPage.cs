using Demo.SeleniumFramework;
using System.Xml.Linq;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Страница регистрации
    /// </summary>
    public class VelocraftRegistrationPage
    {
        WebItemWrap InputLoginField =>
           new WebItemWrap("//h3[contains(@class, 'registration__fields-title') and normalize-space()='Логин:']/following-sibling::input[contains(@class, 'registration__input')]",
               "Поле для ввода логина");

        WebItemWrap InputNameField =>
            new WebItemWrap("//h3[contains(@class, 'registration__fields-title') and normalize-space()='Имя:']/following-sibling::input[contains(@class, 'registration__input')]",
                "Поле для ввода имени");

        WebItemWrap InputSurnameField =>
            new WebItemWrap("//h3[contains(@class, 'registration__fields-title') and normalize-space()='Фамилия:']/following-sibling::input[contains(@class, 'registration__input')]",
                "Поле для ввода фамилии");

        WebItemWrap InputEmailField =>
            new WebItemWrap("//h3[contains(@class, 'registration__fields-title') and normalize-space()='Email:']/following-sibling::input[contains(@class, 'registration__input')]",
                "Поле для ввода email");

        WebItemWrap InputPasswordField =>
            new WebItemWrap("//h3[contains(@class, 'registration__fields-title') and normalize-space()='Пароль:']/following-sibling::input[contains(@class, 'registration__input')]",
                "Поле для ввода пароля");

        WebItemWrap InputRepeatPasswordField =>
            new WebItemWrap(" //h3[contains(@class, 'registration__fields-title') and normalize-space()='Повторите пароль:']/following-sibling::input[contains(@class, 'registration__input')]",
                "Поле для повторения пароля");

        WebItemWrap RegistrationButton =>
            new WebItemWrap("//button[contains(@class, 'registration__submit-button') and normalize-space()='Зарегистрироваться']",
                "Кнопка 'Зарегистрироваться'");
        
        /// <summary>
        /// Выполняет регистрацию пользователя на сайте "Velocraft"
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <returns>Страница авторизации</returns>
        public VelocraftLoginPage Registration(string login, string name, string surname, string email, string password)
        {
            InputLoginField.SendKeys(login);
            InputNameField.SendKeys(name);
            InputSurnameField.SendKeys(surname);
            InputEmailField.SendKeys(email);
            InputPasswordField.SendKeys(password);
            InputRepeatPasswordField.SendKeys(password);
            RegistrationButton.Click();
            return new VelocraftLoginPage();
        }
    }
}
