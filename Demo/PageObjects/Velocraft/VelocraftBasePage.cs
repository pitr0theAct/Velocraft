using Demo.SeleniumFramework;

namespace Demo.PageObjects.Velocraft
{
    /// <summary>
    /// Страница выбора базовых компонентов (рама и вилка) в конструкторе велосипеда.
    /// Содержит методы для выбора рамы и вилки, а также для извлечения и сохранения их геометрических параметров
    /// (диаметров штока) с целью последующей проверки совместимости.
    /// </summary>
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
            string xpathParam = $"//div[@class='item-feature']/dt[contains(text(),'{parameterName}')]/following-sibling::dd[1]";
            var param = new WebItemWrap(xpathParam, $"Параметр {parameterName}");
            param.WaitDisplayed();
            return param.InnerText().Trim();
        }

        /// <summary>
        /// Выбор базовых компонентов велосипеда (рамы и вилки) и сохранения 
        /// параметров этих деталей для последующего их сравнения для проверки совместимости
        /// </summary>
        /// <param name="frameName">Название рамы</param>
        /// <param name="forkName">Название вилки</param>
        /// <returns>Страница со списком колёс</returns>
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
