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


        // Поля для хранения параметров
        private string _frameUpperDiameter;
        private string _frameLowerDiameter;
        private string _forkUpperDiameter;
        private string _forkLowerDiameter;

        // Вспомогательный метод для получения параметра 
        private string GetParameterValue(string parameterName)
        {
            string xpath = $"//div[@class='item-feature']/dt[contains(text(),'{parameterName}')]/following-sibling::dd[1]";
            var param = new WebItemWrap(xpath, $"Параметр {parameterName}");
            param.WaitDisplayed();
            return param.InnerText().Trim();
        }

        public VelocraftWheelsPage ChoosingPartsOfTheBase(string frameName, string forkName)
        {
            //Рама
            FrameImage(frameName).WaitDisplayed();
            FrameImage(frameName).Click();
            FrameImageInDetails(frameName).WaitDisplayed();
            // Сохраняем параметры рамы
            _frameUpperDiameter = GetParameterValue("Диаметр верха штока вилки (мм)");
            _frameLowerDiameter = GetParameterValue("Диаметр низа штока вилки (мм)");
            AddToTheAssemblyButton.Click();
            // Вилка
            ForkImage(forkName).WaitDisplayed();
            ForkImage(forkName).Click();
            ForkImageInDetails(forkName).WaitDisplayed();
            // Сохраняем параметры вилки
            _forkUpperDiameter = GetParameterValue("Диаметр верха штока вилки (мм)");
            _forkLowerDiameter = GetParameterValue("Диаметр низа штока вилки (мм)");
            AddToTheAssemblyButton.Click();
            return new VelocraftWheelsPage(_frameUpperDiameter, _frameLowerDiameter, _forkUpperDiameter, _forkLowerDiameter);
        }

    }

}
