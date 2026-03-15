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

        void CreateCollaboration(MobileAppHomePage homePage)
        {
            // Подготовка
            // Создаем уникальное название задачи
            string collabName = "testCollab" + DateTime.Now.Ticks;
            // Создаем уникальный текст задачи
            string collabText = "textCollab" + DateTime.Now.Ticks;

            // Все работает до моммента ввода названия (все очень медленно)

            // Основная часть
            // Переходим на вкладку мессенджер
            homePage.TabsPanel.SelectMassenger().
            // Нажимаем на плюсик
            OpenCreationMenu().
            //Выбираем коллабу
            // Нажимаем на кнопку продолжить
            // Вводим название, описание
            FillCollaborationForm(collabName, collabText).
            // устанвливаем модератора, и устанвливаем что приглашать участников может только модератор
            FillCollaborationSettings().
            // Создаем коллабу
            CreateCollaboration();

            //Ассерты
            //Названия, описания, модератора, и отсутсвие возможности приглашать гостей
        }

    }
}
