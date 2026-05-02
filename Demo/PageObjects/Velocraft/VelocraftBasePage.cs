using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    public class VelocraftBasePage
    {
        WebItemWrap AddToTheAssemblyButton =>
           new WebItemWrap("//button[contains(@class, 'button_add')]",
                "Нажать на кнопку 'Добавить в сборку'");

        // Рама
        WebItemWrap FrameImage(string name) =>
            new WebItemWrap($"//img[@alt='{name}']", $"Картинка рамы {name}");

        WebItemWrap FrameImageInDetails(string name) =>
            new WebItemWrap($"//section[contains(@class, 'content-info__item-image')]/img[@alt='{name}']",
                $"Картинка рамы в детальном просмотре {name}");

        // Вилка
        WebItemWrap ForkImage(string name) =>
            new WebItemWrap($"//section[contains(@class, 'content-catalog__catalog-container')]//img[contains(@alt, '{name}') and contains(@alt, 'workshop')]", 
                $"Картинка вилки {name}");

        WebItemWrap ForkImageInDetails(string name) =>
            new WebItemWrap($"//section[contains(@class, 'content-info__item-content')]//img[contains(@alt, '{name}')]", 
                $"Картинка вилки {name} в детальном просмотре");

        public VelocraftWheelsPage ChoosingPartsOfTheBase(string frameName, string forkName)
        {
            //Рама
            FrameImage(frameName).WaitDisplayed();
            FrameImage(frameName).Click();
            FrameImageInDetails(frameName).WaitDisplayed();
            AddToTheAssemblyButton.Click();
            // Вилка
            ForkImage(forkName).WaitDisplayed();
            ForkImage(forkName).Click();
            ForkImageInDetails(forkName).WaitDisplayed();
            AddToTheAssemblyButton.Click();
            return new VelocraftWheelsPage();
        }


    }

}
