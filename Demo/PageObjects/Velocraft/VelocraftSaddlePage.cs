using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Страница выбора деталей из категории "Седло"
    /// </summary>
    public class VelocraftSaddlePage
    {
        WebItemWrap AddToTheAssemblyButton =>
           new WebItemWrap("//button[contains(@class, 'button_add')]",
               "Нажать на кнопку 'Добавить в сборку'");

        // Подседельный штырь
        WebItemWrap SeatpostImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Fox Racing Shox Transfer SL Performance Elite 125 mm Seatpost']",
                "Картинка подседельного штыря");

        WebItemWrap SeatpostImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Fox Racing Shox Transfer SL Performance Elite 125 mm Seatpost']",
                "Картинка подседельного штыря в детальном просмотре");

        // Рычаг дроппера
        WebItemWrap DropperLevelImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Hope Dropper Lever Handlebar Remote']",
                "Картинка дроппера");

        WebItemWrap DropperLevelImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'Hope Dropper Lever Handlebar Remote')]",
                "Картинка дроппера в детальном просмотре");

        // Седло
        WebItemWrap SaddleImage(string name) =>
            new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='{name}']",
                "Картинка седла");

        WebItemWrap SaddleImageInDetails(string name) =>
            new WebItemWrap($"//section[contains(@class, 'content-info__item')]//img[contains(@alt, '{name}')]",
                "Картинка седла в детальном просмотре");

        /// <summary>
        /// Выполняет последовательное добавление всех деталей из категории "Седло"
        /// </summary>
        /// <param name="saddleName"></param>
        /// <returns>Главная страница <see cref="VelocraftHomePageIlya"/> после завершения выбора компонентов седла</returns>
        /// <remarks>
        /// Каждый компонент выбирается кликом по его изображению, ожидается загрузка детального просмотра,
        /// затем нажимается кнопка «Добавить в сборку».
        /// Перед кликом для каждого элемента выполняется прокрутка к элементу (ScrollIntoView).
        /// </remarks>
        public VelocraftHomePageIlya ChoosingPartsOfTheSaddle(string saddleName)
        {
            // Подседельный штырь
            SeatpostImage.ScrollIntoView(alignToTop: false);
            SeatpostImage.WaitDisplayed();
            SeatpostImage.Click();
            SeatpostImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Рычаг дроппера
            DropperLevelImage.ScrollIntoView(alignToTop: false);
            DropperLevelImage.WaitDisplayed();
            DropperLevelImage.Click();
            DropperLevelImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Седло
            SaddleImage(saddleName).ScrollIntoView(alignToTop: false);
            SaddleImage(saddleName).WaitDisplayed();
            SaddleImage(saddleName).Click();
            SaddleImageInDetails(saddleName).WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftHomePageIlya();
        }
    }
}
