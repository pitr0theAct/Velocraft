using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Страница выбора тормозных компонентов (дисковые тормоза, задний и передний тормозные диски) в конструкторе велосипеда.
    /// </summary>
    public class VelocraftBrakesPage
    {
        WebItemWrap AddToTheAssemblyButton =>
            new WebItemWrap("//button[contains(@class, 'button_add')]",
                "Нажать на кнопку 'Добавить в сборку'");

        // Дисковые тормоза
        WebItemWrap DiskBrakesImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Magura MT7 Pro HC Carbotecture Disc Brake Set']",
                "Картинка дисковых тормозов");

        WebItemWrap DiskBrakesImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Magura MT7 Pro HC Carbotecture Disc Brake Set']",
                "Картинка дисковых тормозов в детальном просмотре");

        // Задний тормозной диск
        WebItemWrap RearBrakesDiscImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'GALFER Fixed Disc Shark 1.8 mm MTB Center Lock Brake Rotor')]",
                "Картинка заднего тормозного диска");

        WebItemWrap RearBrakesDiscImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'GALFER Fixed Disc Shark 1.8 mm MTB Center Lock Brake Rotor')]",
                "Картинка заднего тормозного диска в детальном просмотре");

        // Передний тормозной диск
        WebItemWrap FrontBrakesDiscImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'SRAM Centerline Rounded 6-bolt Brake Rotors, 1-Piece')]",
                "Картинка переднего тормозного диска");

        WebItemWrap FrontBrakesDiscImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'SRAM Centerline Rounded 6-bolt Brake Rotors, 1-Piece')]",
                "Картинка переднего тормозного диска в детальном просмотре");

        /// <summary>
        /// Выполняет последовательное добавление всех тормозных компонентов в сборку
        /// </summary>
        /// <returns>Страница выбора деталей из категории "Седло"<see cref="VelocraftSaddlePage"/></returns>
        /// <remarks>
        /// Каждый компонент выбирается кликом по его изображению, ожидается загрузка детального просмотра,
        /// затем нажимается кнопка «Добавить в сборку».
        /// Для дисковых тормозов и заднего тормозного диска перед кликом выполняется прокрутка к элементу (ScrollIntoView).
        /// </remarks>
        public VelocraftSaddlePage ChoosingPartsOfTheBrakes()
        {
            // Дисковые тормоза
            DiskBrakesImage.ScrollIntoView(alignToTop: false);
            DiskBrakesImage.WaitDisplayed();
            DiskBrakesImage.Click();
            DiskBrakesImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Задний тормозной диск
            RearBrakesDiscImage.ScrollIntoView(alignToTop: false);
            RearBrakesDiscImage.WaitDisplayed();
            RearBrakesDiscImage.Click();
            RearBrakesDiscImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Передний тормозной диск
            FrontBrakesDiscImage.WaitDisplayed();
            FrontBrakesDiscImage.Click();
            FrontBrakesDiscImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftSaddlePage();
        }
    }
}
