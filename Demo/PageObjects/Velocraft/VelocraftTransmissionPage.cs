using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    public class VelocraftTransmissionPage
    {
        WebItemWrap AddToTheAssemblyButton =>
            new WebItemWrap("//button[contains(@class, 'button_add')]",
                "Нажать на кнопку 'Добавить в сборку'");
       
        // Кассета
        WebItemWrap CassetteImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Shimano Deore CS-M6100-12 12-Speed Cassette 10-51']",
                "Картинка кассеты");

        WebItemWrap CassetteImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Shimano Deore CS-M6100-12 12-Speed Cassette 10-51']",
                "Картинка кассеты в детальном просмотре");

        // Переключатель
        WebItemWrap SwitchImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Shimano XT RD-M8100 12-speed Shadow Plus Rear Derailleur']",
                "Картинка переключателя");

        WebItemWrap SwitchImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[@alt='Shimano XT RD-M8100 12-speed Shadow Plus Rear Derailleur']",
                "Картинка переключателя в детальном просмотре");

        // Манетки
        WebItemWrap ManettesImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container') and not(contains(@class, '--build'))]//img[@alt='Shimano Deore SL-M6100 12-speed Shifter w/ Clamp']",
                "Картинка манетки");

        WebItemWrap ManettesImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Shimano Deore SL-M6100 12-speed Shifter w/ Clamp']",
                "Картинка манетки в детальном просмотре");

        // Система
        WebItemWrap SystemImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'SRAM X0 Eagle Transmission AXS DUB 1x12-Speed Power Meter Crankset')]",
                "Картинка системы");

        WebItemWrap SystemImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[contains(@alt, 'SRAM X0 Eagle Transmission')]",
                "Картинка системы в детальном просмотре");

        // Каретка
        WebItemWrap CarriageImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, 'SRAM BSA DUB MTB SuperBoost+ 73 mm')]",
                "Картинка каретки");

        WebItemWrap CarriageImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='SRAM BSA DUB MTB SuperBoost+ 73 mm Bottom Bracket']",
                "Картинка каретки в детальном просмотре");
        // Цепь
        WebItemWrap ChainImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='SRAM PC NX Eagle 12-speed chain - workshop packaging']",
                "Картинка цепи");

        WebItemWrap ChainImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[@alt='SRAM PC NX Eagle 12-speed chain - workshop packaging']",
                "Картинка цепи в детальном просмотре");
        // Педали
        WebItemWrap PedalsImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='e*thirteen Base Flat Platform Pedals']",
                "Картинка педали");

        WebItemWrap PedalsImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[contains(@alt, 'e*thirteen Base Flat Platform Pedals')]",
                "Картинка педали в детальном просмотре");

        public VelocraftHandlebarPage ChoosingPartsOfTheTransmission()
        {
            // Кассета
            CassetteImage.WaitDisplayed();
            CassetteImage.Click();
            CassetteImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Переключатель
            SwitchImage.WaitDisplayed();
            SwitchImage.Click();
            SwitchImageInDetails.WaitDisplayed(15);
            AddToTheAssemblyButton.Click();
            ////WaitersCore.Wait_s(10);
            // Манетки
            ManettesImage.WaitDisplayed(15);
            ManettesImage.Click();
            ManettesImageInDetails.WaitDisplayed(15);
            AddToTheAssemblyButton.Click();
            // Система
            SystemImage.WaitDisplayed();
            SystemImage.Click();
            SystemImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Каретка
            CarriageImage.WaitDisplayed();
            CarriageImage.Click();
            CarriageImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Цепь
            ChainImage.WaitDisplayed();
            ChainImage.Click();
            ChainImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Педали
            PedalsImage.WaitDisplayed();
            PedalsImage.Click();
            PedalsImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftHandlebarPage();
        }
    }
}
