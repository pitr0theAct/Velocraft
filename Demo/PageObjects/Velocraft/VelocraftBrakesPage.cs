using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
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

        public VelocraftSaddlePage ChoosingPartsOfTheBrakes()
        {
            // Дисковые тормоза
            DiskBrakesImage.WaitDisplayed();
            DiskBrakesImage.Click();
            DiskBrakesImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Задний тормозной диск
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
