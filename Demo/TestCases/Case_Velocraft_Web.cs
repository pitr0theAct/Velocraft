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
            };
        }

        public static void AddFrame(WebHomePage homePage)
        {
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
    }
}