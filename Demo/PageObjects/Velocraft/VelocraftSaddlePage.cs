using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
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
        WebItemWrap SaddleImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Chromag Overture LTD Saddle']",
                "Картинка седла");

        WebItemWrap SaddleImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'Chromag Overture LTD Saddle')]",
                "Картинка седла в детальном просмотре");

        public VelocraftHomePageIlya ChoosingPartsOfTheSaddle()
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
            SaddleImage.ScrollIntoView(alignToTop: false);
            SaddleImage.WaitDisplayed();
            SaddleImage.Click();
            SaddleImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftHomePageIlya();
        }
    }
}
