using Demo.BaseFramework;
using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    public class VelocraftHandlebarPage
    {
        WebItemWrap AddToTheAssemblyButton =>
           new WebItemWrap("//button[contains(@class, 'button_add')]",
               "Нажать на кнопку 'Добавить в сборку'");

        // Кнопка пагинации
        //WebItemWrap PaginationButton =>
        //    new WebItemWrap("//button[contains(@class, 'pagination__button') and text()='2']",
        //        "Нажать на кнопку '2' на панели пагинации");

        //WebItemWrap PaginationButtonActive =>
        //    new WebItemWrap("//button[contains(@class, 'pagination__button') and text()='2' and contains(@class, '--active')]",
        //        "Кнопка пагинации '2' активна");

        // Рулевая колонка
        WebItemWrap SteeringColumnImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Cane Creek Hellbender 70 ZS44/28.6 - ZS56/40 Headset']",
                "Картинка рулевой колонки");

        WebItemWrap SteeringColumnImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Cane Creek Hellbender 70 ZS44/28.6 - ZS56/40 Headset']",
                "Картинка рулевой колонки в детальном просмотре");

        // Вынос руля
        WebItemWrap HandlebarStemImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Chromag HIFI 35 Stem']",
                "Картинка выноса руля");

        WebItemWrap HandlebarStemImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[@alt='Shimano XT RD-M8100 12-speed Shadow Plus Rear Derailleur']",
                "Картинка выноса руля в детальном просмотре");

        // Руль

        //WebItemWrap HandlebarImage =>
        //    new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'OneUp Components V2 Carbon')]",
        //        "Картинка руля");

        //WebItemWrap HandlebarImageInDetails =>
        //    new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[@alt='OneUp Components V2 Carbon 800 mm 35 mm 20 mm Riser Handlebar']",
        //        "Картинка руля в детальном просмотре");

        WebItemWrap HandlebarImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'LEVEL') and contains(@alt, 'Riser Handlebar')]",
                "Картинка руля");

        WebItemWrap HandlebarImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'mainlayout__content-info')]//img[contains(@alt, 'LEVELNINE MTB 35 10 mm Riser Handlebar')]",
                "Картинка руля в детальном просмотре");

        // Грипсы
        WebItemWrap GripsImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'ODI Troy Lee Designs MTB Lock-On Handlebar Grips')]",
                "Картинка грипсы");

        WebItemWrap GripsImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[contains(@alt, 'ODI Troy Lee Designs MTB Lock-On Handlebar Grips')]",
                "Картинка грипсы в детальном просмотре");

        public VelocraftBrakesPage ChoosingPartsOfTheHandlebar()
        {
            // Рулевая колонка
            SteeringColumnImage.WaitDisplayed();
            SteeringColumnImage.Click();
            SteeringColumnImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Вынос руля
            HandlebarStemImage.WaitDisplayed();
            HandlebarStemImage.Click();
            HandlebarStemImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            ////WaitersCore.Wait_s(10);
            // Руль
            //PaginationButton.Click();
            //PaginationButtonActive.WaitDisplayed(10);
            HandlebarImage.WaitDisplayed();
            HandlebarImage.Click();
            HandlebarImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Грипсы
            GripsImage.WaitDisplayed();
            GripsImage.Click();
            GripsImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftBrakesPage();
        }
    }
}
