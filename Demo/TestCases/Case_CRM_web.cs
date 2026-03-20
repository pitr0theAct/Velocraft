using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.BaseFramework.ScriptInterraction;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;

namespace Demo.TestCases
{
    public class Case_CRM_web : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            return new List<ExecutableTestCase>
            {
                new ExecutableTestCase("Запуск робота 'Запланировать дело' в CRM",
                homePage => PlanDealRobot(homePage)),
            };
        }

        public static void PlanDealRobot(WebHomePage homePage)
        {
            // Подготовка
            // Создать сделку СRM
            string dealName = HelperMethodsCore.GetDateTimeSalt() + "_dealName";
            var phpExecutor = new PHPexecutor(ExecutableTestCase.RunningTestCase.TestPortal.Adress,
                ExecutableTestCase.RunningTestCase.TestPortal.Admin.Login,
                ExecutableTestCase.RunningTestCase.TestPortal.Admin.Password);
            string dealCreationPhpCode = $"\\Bitrix\\Main\\Loader::includeModule('crm');\r\n$entityFields = " +
                $"[\r\n\r\n    'TITLE'    => '{dealName}',\r\n    " +
                $"'STAGE_ID' => 'NEW',\r\n];\r\n$entityObject = new \\CCrmDeal( $bCheckRight );\r\n$entityId = $entityObject->" +
                $"Add(\r\n    $entityFields,\r\n    $bUpdateSearch = true,\r\n    $arOptions = [\r\n        'CURRENT_USER' => " +
                $"\\CCrmSecurityHelper::GetCurrentUserID(),\r\n        'DISABLE_USER_FIELD_CHECK' => " +
                $"false,\r\n        'DISABLE_REQUIRED_USER_FIELD_CHECK' => false,\r\n    ]\r\n);";
            phpExecutor.Execute(dealCreationPhpCode);
            // Добавить пользователя на протал
            var testResponsible = ExecutableTestCase.RunningTestCase.CreatePortalTestUser(false);
            // Уникальная добавка к названия дела робота
            string robotDealName = "_" + HelperMethodsCore.GetDateTimeSalt();

            // Основная часть
            homePage.SideMenu
            // CRM
                .OpenCRM()
            // Роботы
                .OpenRobotPage()
            // Создать
                .OpenRobotCreationPage()
            // Выбираем Запланировать дело
                .SelectRobotAction()
            // Заполняем данные и сохраняем
                .FillRobotCreationForm(robotDealName, testResponsible)
            // Сохранить
                .SaveRobotSettings()
            // Закрыть Вкладку
                .CloseRobotPage()
            // Перенести дело в нужную вкладку
                .ChangeDealStatus(dealName)
            // Перед ассретами нужно дать пользователю права на доступ к CRM
            // Открыть права доступа на старнице CRM
                .OpenCRMAccessRights()
            // Открыть страницу настройки прав
                .OpenRightsManagingPage()
            // Выдать права
                .AddUserRights(testResponsible)
            // Сохранить
                .SaveUserRights();

            // Ассерты
            // Авторизироватся под другим пользователем
            var driver2 = DriverActionsWeb.CreateNewDriver();
            var homePage2 = new WebLoginPage(ExecutableTestCase.RunningTestCase.TestPortal, driver2).Login(testResponsible);
            var dealDetailsPage = homePage2.SideMenu
            // Перейти в CRM 
                .OpenCRM()
            // Нажать на имя сделки
                .OpenDealDetails(dealName); 

            // Проверить название дела созданного роботом
            dealDetailsPage.AssertRobotDeal(robotDealName);

            // Проверить пользователя отвественного за дело созданное роботом
            bool isResponsiblePresent = dealDetailsPage.AssertResposible(testResponsible);
            if (!isResponsiblePresent)
            {
                Log.Error($"Ответсвенный за дело созданное роботом {testResponsible.NameLastName} " +
                    $"не отображается на детальной странице сделки в CRM");
            }

            // Постусловия
            // Закрываем второй драйвер
            driver2.Close();

            homePage.SideMenu
            // CRM
                .OpenCRM()
            // Роботы
                .OpenRobotPage()
            // Удаляем созданного робота
                .DeleteRobot(testResponsible);
        }
    }
}
