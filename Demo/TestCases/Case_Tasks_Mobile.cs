using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.PageObjects.Mobile;
using Demo.TestEntities;

namespace Demo.TestCases
{

    public class Case_Tasks_Mobile : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            var caseCollection = new List<ExecutableTestCase>();
            caseCollection.Add(
                new ExecutableTestCase("Базовое создание задачи", mobileHomePage => CreateTask(mobileHomePage)));
            caseCollection.Add(
                new ExecutableTestCase("Создания коллабы в мессенджере", mobileHomePage => CreateCollaboration(mobileHomePage)));
            return caseCollection;
        }

        void CreateTask(MobileAppHomePage homePage)
        {
            string taskName = "testTask" + DateTime.Now.Ticks;
            var testTask = new B24TaskEntity(taskName);

            bool isTaskPresent = homePage.TabsPanel
                .SelectTasks()
                .CreateTask(testTask)
                .IsTaskDisplayed(testTask);

            if (!isTaskPresent)
            {
                Log.Error($"Задача с названием {taskName} не отображается");
            }
        }

        /// <summary>
        /// Проверка создания коллаборации в мобильном приложении на android
        /// </summary>
        /// <param name="homePage"></param>
        void CreateCollaboration(MobileAppHomePage homePage)
        {
            // Подготовка
            // Создаем уникальное название и текст коллабы
            string collabName = "testCollab" + DateTime.Now.Ticks;
            string collabText = "textCollab" + DateTime.Now.Ticks;
            var testCollab = new B24CollaborationEntity(collabName, collabText);
            // Добавляем пользователя котрый будет модератором
            var testModerator = ExecutableTestCase.RunningTestCase.CreatePortalTestUser(false);

            // Переходим на вкладку мессенджер
            homePage.TabsPanel.SelectMassenger().
            // Нажимаем на плюсик
                OpenCreationMenu().
            // Выбираем коллабу, вводим название и описание
                FillCollaborationForm(testCollab).
            // Устанвливаем модератора, отключаем возможность приглашения гостей
                FillCollaborationSettings(testModerator).
            // Создаем коллабу
                CreateCollaboration();
            // Проверяем наличие коллабы с названием и описанием, также все заданные права
        }

    }
}
