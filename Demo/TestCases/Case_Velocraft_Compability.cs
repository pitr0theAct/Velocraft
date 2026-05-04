using Demo.BaseFramework;
using Demo.PageObjects;
using Demo.PageObjects.Velocraft;
using System.Xml.Linq;

namespace Demo.TestCases
{
    public class Case_Velocraft_Compability
    {
        public class Case_Velocraft_Configurator : TestCaseCollectionBuilder
        {
            protected override List<ExecutableTestCase> GetCases()
            {
                var caseCollection = new List<ExecutableTestCase>();
                caseCollection.Add(new ExecutableTestCase("Проверка совместимости деталей (Velocraft)", (Action<WebHomePage>)(homePage =>
                {
                    var mainPage = new VelocraftMainPage(homePage.Driver);
                    CheckCompability(mainPage);
                })));
                return caseCollection;
            }
            void CheckCompability(VelocraftMainPage homePage)
            {
                // Данные для регистрации
                string login = "testuser_" + HelperMethodsCore.GetDateTimeSalt();
                string email = login + "@example.com";
                string password = "Qwerty123";
                string name = "Test" + HelperMethodsCore.GetDateTimeSalt(); 
                string surname = "User" + HelperMethodsCore.GetDateTimeSalt(); 

                string frameName = "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";
                string forkName = "RockShox Domain Gold R DebonAir Boost 29";

                var loginPage = homePage
                // Ввод роста и веса
                .EnteringHeightAndWeight()
                // Переходим на страницу авторизации
                .GoToAuthorizationPage()
                // Переходим на страницу регистрации
                .GoToRegistrationPage()
                // Регистрация
                .Registration(login, name, surname, email, password)
                // Проверка успешности регистрации
                .AssertRegistrationSuccess();
                var wheelsPage = loginPage
                // Авторизация
                .Authorization(login, password)
                 //Перейти в категорию сборки "Основа"
                .OpenBase()
                // Выбор деталей для категории "Основа"
                .ChoosingPartsOfTheBase(frameName, forkName)
                // Проверка совместимости
                .AssertCheckFrameAndForkCompability();
            }
        }
    }
}
