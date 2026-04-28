using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.BaseFramework.ScriptInterraction;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;

namespace Demo.TestCases
{
    public class Case_Velocraft_web : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            return new List<ExecutableTestCase>
            {
                new ExecutableTestCase("Проверка сайта Veocraft",
                homePage => TestVelocraft(homePage)),
            };
        }

        public static void TestVelocraft(WebHomePage homePage)
        {
            Thread.Sleep(100);
            homePage.ClosePopUp();
        }
    }
}