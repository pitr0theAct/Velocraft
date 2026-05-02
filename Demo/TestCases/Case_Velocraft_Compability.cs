using Demo.BaseFramework;
using Demo.PageObjects;
using Demo.PageObjects.Velocraft;

namespace Demo.TestCases
{
    public class Case_Velocraft_Compability
    {
        public class Case_Velocraft_Configurator : TestCaseCollectionBuilder
        {
            protected override List<ExecutableTestCase> GetCases()
            {
                var caseCollection = new List<ExecutableTestCase>();
                caseCollection.Add(new ExecutableTestCase("Проверка совместимости деталей", (Action<WebHomePage>)(homePage =>
                {
                    var ilyaHome = new VelocraftHomePageIlya(homePage.Driver);
                    CheckCompability(ilyaHome);
                })));
                return caseCollection;
            }
            void CheckCompability(VelocraftHomePageIlya homePage)
            {
                string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";
                string forkName = "RockShox Domain Gold R DebonAir Boost 29";

                var VelocraftBasePage = homePage
                // Ввод роста и веса
                .EnteringHeightAndWeight()
                // Перейти в категорию сборки "Основа"
                .OpenBase()
                // Выбор деталей для категории "Основа"
                .ChoosingPartsOfTheBase(frameName, forkName);
                VelocraftBasePage
                // Проверка совместимости
                .AssertCheckFrameAndForkCompability(frameName, forkName);
            }
        }
    }
}
