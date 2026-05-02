using Demo.BaseFramework;
using Demo.PageObjects;
using Demo.PageObjects.Velocraft;

namespace Demo.TestCases
{
    public class Case_Velocraft_Configurator : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            var caseCollection = new List<ExecutableTestCase>();
            caseCollection.Add(new ExecutableTestCase("Полный проход конфигуратора с сохранением сборки", homePage =>
            {
                var ilyaHome = new VelocraftHomePageIlya(homePage.Driver);
                FullConfiguratorPass(ilyaHome);
            }));
            return caseCollection;
        }

        void FullConfiguratorPass(VelocraftHomePageIlya homePage)
        {
            string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";
            string forkName = "RockShox Domain Gold R DebonAir Boost 29";

            var VelocraftBasePage = homePage
                // Ввод роста и веса
                .EnteringHeightAndWeight()
                // Перейти в категорию сборки "Основа"
                .OpenBase()
                // Выбор деталей для категории "Основа"
                .ChoosingPartsOfTheBase(frameName, forkName)
                // Выбор деталей для категории "Колёса"
                .ChoosingPartsOfTheWheels()
                // Выбор деталей для категории "Трансмиссия"
                .ChoosingPartsOfTheTransmission()
                // Выбор деталей для категории "Руль"
                .ChoosingPartsOfTheHandlebar()
                // Выбор деталей для категории "Тормоза"
                .ChoosingPartsOfTheBrakes()
                // Выбор деталей для категории "Седло"
                .ChoosingPartsOfTheSaddle()
                // Сохранение сборки
                .SavingBuild();
                // Ассерт сохранения сборки

                Thread.Sleep(50000);
        }
    }

}