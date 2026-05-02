using Demo.BaseFramework;
using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    public class VelocraftWheelsPage
    {
        WebItemWrap AddToTheAssemblyButton =>
            new WebItemWrap("//button[contains(@class, 'button_add')]",
                "Нажать на кнопку 'Добавить в сборку'");

        WebItemWrap WheelsetImage =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container') and not(contains(@class, '--build'))]//img[contains(@alt, 'bc original Loamer MK2 Center Lock Disc 29')]", 
                "Картинка колёсной пары");

        WebItemWrap WheelsetImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-content')]//img[contains(@alt, 'bc original Loamer MK2 Center Lock Disc 29')]",
                "Картинка колёсной пары в детальном просмотре");

        WebItemWrap FrameRearTire =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container') and not(contains(@class, '--build'))]//div[contains(@class, 'catalog-item__image')]/img[contains(@alt, 'Specialized Butcher Grid Trail T9')]", 
                "Картинка задней покрышки");

        WebItemWrap RearTireImageInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item-image')]/img[contains(@alt, 'Specialized Butcher Grid Trail T9')]",
                "Картинка задней покрышки в детальном просмотре");

        WebItemWrap ActiveFrontTireCategory =>
            new WebItemWrap("//div[contains(@class, 'content-catalog__category-item') and contains(@class, '--active') and .//p[text()='Передняя покрышка']]",
                "Категория 'Передняя покрышка' активна");

        WebItemWrap FrameFrontTire =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//div[contains(@class, 'content-catalog__item')]//img[contains(@alt, 'Eliminator Grid Trail T7')]", 
                "Картинка передней покрышки");

        WebItemWrap FrameFrontTireInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'Eliminator Grid Trail T7')]", 
                "Картинка передней покрышки в детальном просмотре");

        WebItemWrap ActiveRearCameraCategory =>
            new WebItemWrap("//div[contains(@class, 'content-catalog__category-item') and contains(@class, '--active')]//p[text()='Задняя камера']",
                "Категория 'Задняя камера' активна");

        WebItemWrap FrameRearCamera =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Schwalbe Inner Tube 19F for 27.5+/29/29+']",
                "Картинка задней камеры");

        WebItemWrap FrameRearCameraInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[contains(@alt, 'Schwalbe Inner Tube 19F')]",
                "Картинка задней камеры в детальном просмотре");

        WebItemWrap ActiveFrontCameraCategory =>
            new WebItemWrap("//div[contains(@class, 'content-catalog__category-item') and contains(@class, '--active')]//p[text()='Передняя камера']",
                "Категория 'Передняя камера' активна");

        WebItemWrap FrameFrontCamera =>
            new WebItemWrap("//section[contains(@class, 'content-catalog__catalog-container')]//img[@alt='Schwalbe Inner Tube 19+ Air Plus for 29+']",
                "Картинка передней камеры");

        WebItemWrap FrameFrontCameraInDetails =>
            new WebItemWrap("//section[contains(@class, 'content-info__item')]//img[@alt='Schwalbe Inner Tube 19+ Air Plus for 29+']",
                "Картинка передней камеры в детальном просмотре");
        
        public VelocraftTransmissionPage ChoosingPartsOfTheWheels()
        {
            // Колёсная пара
            WheelsetImage.WaitDisplayed();
            WheelsetImage.Click();
            WheelsetImageInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Задняя покрышка
            FrameRearTire.WaitDisplayed();
            FrameRearTire.Click();
            RearTireImageInDetails.WaitDisplayed(15);
            AddToTheAssemblyButton.Click();
            //WaitersCore.Wait_s(10);
            // Передняя покрышка
            ActiveFrontTireCategory.WaitDisplayed(10);
            FrameFrontTire.WaitDisplayed(15);
            FrameFrontTire.Click();
            FrameFrontTireInDetails.WaitDisplayed(15);
            AddToTheAssemblyButton.Click();
            // Задняя камера
            ActiveRearCameraCategory.WaitDisplayed(10);
            FrameRearCamera.WaitDisplayed();
            FrameRearCamera.Click();
            FrameRearCameraInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Передняя камера
            ActiveFrontCameraCategory.WaitDisplayed(10);
            FrameFrontCamera.WaitDisplayed();
            FrameFrontCamera.Click();
            FrameFrontCameraInDetails.WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftTransmissionPage();
        }

        public VelocraftWheelsPage AssertCheckFrameAndForkCompability()
        {

            return new VelocraftWheelsPage();
        }
    }
}
