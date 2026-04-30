using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.BaseFramework.ScriptInterraction;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;
using OpenQA.Selenium.DevTools.V143.Page;

namespace Demo.TestCases
{
    public class Case_Velocraft_web : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            return new List<ExecutableTestCase>
            {
                new ExecutableTestCase("Базовое добавление детали в сборку",
                homePage => AddFrame(homePage)),

                new ExecutableTestCase("Сброс конфигурации при замене рамы",
                homePage => ResetConfigAfterFrameSwap(homePage)),
            };
        }

        public static void AddFrame(WebHomePage homePage)
        {
            // Название рамы
            string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";

            // Открываем сайт
            bool isFramePresent = homePage
                // Закрываем popUp с вводом роста и веса
                .ClosePopUp()
                // Добавляем раму в сборку
                .AddFrame(frameName)
                // Проверка наличия рамы в сборке
                .AssertFrameName(frameName);

            if (!isFramePresent)
            {
                Log.Error($"Название рамы {frameName} " +
                    $"не отображается в блоке Просмотр сборки");
            }
        }

        public static void ResetConfigAfterFrameSwap(WebHomePage homePage)
        {
            // Названия добавляемых деталий
            string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";
            string forkName = "RockShox Domain Gold R DebonAir Boost 29";
            string weelsName = "bc original Loamer MK2 Center Lock Disc 29";
            string tiresName = "Specialized Butcher Grid Trail T9";
            string newFrameName = "Specialized Chisel Hardtail 29 Frame Kit - M Gloss Purple";

            // Открываем сайт
            var resetedConfig = homePage.ClosePopUp()
            // Добавляем Раму
                .AddFrame(frameName)
            // Добавляем Вилку
                .AddFork(forkName)
            // Добавляем Колеса
                .AddWeels(weelsName)
            // Добавляем Покрышки
                .AddTires(tiresName)
            // Возвращаемся к раме и добавляем новую раму
                .AddFrame(newFrameName)
            // Подтверждаем действие
                .ConfirmFrameChange();

            // Ассерты
            // Проверка наличния новой рамы в сборке
            bool isFramePresent = resetedConfig.AssertFrameName(newFrameName);
            if (!isFramePresent)
            {
                Log.Error($"Название рамы {frameName} " +
                    $"не отображается в блоке Просмотр сборки");
            }

            // Проверка сброса старых деталей
            bool isFrameReseted = resetedConfig.HaveNoFrame(frameName);
            if (isFrameReseted)
            {
                Log.Error($"Рама {frameName} не сбросилась из блока Просмотр сборки");
            }

            bool isForkReseted = resetedConfig.HaveNoFrame(forkName);
            if (isForkReseted)
            {
                Log.Error($"Вилка {forkName} не сбросилась из блока Просмотр сборки");
            }

            bool isWeelsReseted = resetedConfig.HaveNoFrame(weelsName);
            if (isWeelsReseted)
            {
                Log.Error($"Колеса {weelsName} на сбросились из блока Просмотр сборки");
            }

            bool isTiresReseted = resetedConfig.HaveNoFrame(tiresName);
            if (isTiresReseted)
            {
                Log.Error($"Покрышки {tiresName} не сбросились из блока Просмотр сборки");
            }
        }
    }
}