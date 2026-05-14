using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.BaseFramework.ScriptInterraction;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;
using Demo.TestEntities;
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
            string frameName = VelocraftTestData.DefaultFrameName;
            string brandName = VelocraftTestData.DefaultBrandName;

            // Открываем сайт
            homePage
            // Закрываем popUp с вводом роста и веса
                .ClosePopUp()
            // Добавляем раму в сборку
                .AddFrame(frameName)
            // Проверка наличия рамы в сборке
                .AssertFramePresent(frameName)
            // Проверка наличия названия бренда
                .AssertFrameBrand(brandName);
        }

        /// <summary>
        /// Автотест сброса сборки после изменения рамы
        /// </summary>
        /// <param name="homePage"></param>
        public static void ResetConfigAfterFrameSwap(VelocraftHomePage homePage)
        {
            // Названия добавляемых деталий
            string frameName = VelocraftTestData.DefaultFrameName;
            string forkName = VelocraftTestData.DefaultForkName;
            string weelsName = VelocraftTestData.DefaultWheelsName;
            string tiresName = VelocraftTestData.DefaultTiresName;
            string newFrameName = VelocraftTestData.AlternativeFrameName;

            // Открываем сайт
            homePage.ClosePopUp()
            // Добавляем Раму
                .AddFrame(frameName)
            // Добавляем Вилку
                .AddPart(forkName, "Вилка")
            // Добавляем Колеса
                .AddPart(weelsName, "Колеса")
            // Добавляем Покрышки
                .AddPart(tiresName, "Покрышки")
            // Возвращаемся к раме и добавляем новую раму
                .AddFrame(newFrameName)
            // Подтверждаем действие
                .ConfirmFrameChange()
            // Ассерты
            // Проверка наличния новой рамы в сборке
                .AssertFramePresent(newFrameName)
            // Проверка сброса старых деталей
                .AssertPartsReset(frameName, forkName, weelsName, tiresName);
        }
        
        /// <summary>
        /// Автотест Запрет перехода без выбора предыдущей категории
        /// </summary>
        /// <param name="homePage"></param>
        public static void CategorySelectionSkipStepBlocked(VelocraftHomePage homePage)
        {
            string frameName = VelocraftTestData.DefaultFrameName;
            
            // Открываем сайт конфигуратора
            homePage.ClosePopUp()
            // Пытаемся перейти в новую категорию «Вилка», не выбрав деталь в предыдущей категории «Рама»
                .OpenBase()
                .OpenFork()
            // Проверяем наличе сообщения о том, что сначала нужно выбрать раму
                .AssertCatalogEmpty("Каталог вилок не пуст без выбора рамы")
            // Выбираем первую деталь в категории «Рама»
                .AddFrame(frameName)
            // Проверяем, что теперь выбор вилки доступен
                .AssertCatalogNotEmpty("Каталог вилок пуст после выбора рамы");
        }
    }
}