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
                new ExecutableTestCase("Базовое добавление детали в сборку (Velocraft)",
                homePage => AddFrame(homePage)),

                new ExecutableTestCase("Сброс конфигурации при замене рамы (Velocraft)",
                homePage => ResetConfigAfterFrameSwap(homePage)),

                new ExecutableTestCase("Запрет перехода на следующий шаг без выбора предыдущей категории (Velocraft)",
                homePage => CategorySelectionSkipStepBlocked(homePage)),

            };
        }

        /// <summary>
        /// Автотест добавления рамы в сборку
        /// </summary>
        /// <param name="homePage"></param>
        public static void AddFrame(VelocraftHomePage homePage)
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

        /// <summary>
        /// Автотест сброса сборки после изменения рамы
        /// </summary>
        /// <param name="homePage"></param>
        public static void ResetConfigAfterFrameSwap(VelocraftHomePage homePage)
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

            bool isForkReseted = resetedConfig.HaveNoFork(forkName);
            if (isForkReseted)
            {
                Log.Error($"Вилка {forkName} не сбросилась из блока Просмотр сборки");
            }

            bool isWeelsReseted = resetedConfig.HaveNoWeels(weelsName);
            if (isWeelsReseted)
            {
                Log.Error($"Колеса {weelsName} на сбросились из блока Просмотр сборки");
            }

            bool isTiresReseted = resetedConfig.HaveNoTires(tiresName);
            if (isTiresReseted)
            {
                Log.Error($"Покрышки {tiresName} не сбросились из блока Просмотр сборки");
            }
        }
        
        /// <summary>
        /// Автотест Запрет перехода без выбора предыдущей категории
        /// </summary>
        /// <param name="homePage"></param>
        public static void CategorySelectionSkipStepBlocked(VelocraftHomePage homePage)
        {
            string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";
            
            // Открываем сайт конфигуратора
            var forkSelection = homePage.ClosePopUp()
            // Пытаемся перейти в новую категорию «Вилка», не выбрав деталь в предыдущей категории «Рама»
                .OpenBase()
                .OpenFork();
            // Проверяем наличе сообщения о том, что сначала нужно выбрать раму
            var isCatalogEmptyBefore = forkSelection.AssertEmptyCatalog();
            if (!isCatalogEmptyBefore)
            {
                Log.Error("Катоалог вилок не пуст без выбора рамы");
            }
            
            // Выбираем первую деталь в категории «Рама»
            var IsCatalogEmptyAfter = forkSelection.AddFrame(frameName)
            // Проверяем, что теперь выбор вилки доступен
                .AssertEmptyCatalog();
            if (IsCatalogEmptyAfter)
            {
                Log.Error("Каталог пуст вилок пуст после выбора рамы");
            }
        }
    }
}