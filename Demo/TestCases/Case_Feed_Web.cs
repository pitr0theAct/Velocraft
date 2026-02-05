using Demo.BaseFramework;
using Demo.BaseFramework.LogTools;
using Demo.PageObjects;
using Demo.SeleniumFramework.DriverActions;

namespace Demo.TestCases
{
    public class Case_Feed_Web : TestCaseCollectionBuilder
    {
        protected override List<ExecutableTestCase> GetCases()
        {
            return new List<ExecutableTestCase>
            {
                new ExecutableTestCase("Создание ответа на комментарий от другого юзера под постом в ленте", homePage => PostCommentReply(homePage)),
            };
        }

        public static void PostCommentReply(WebHomePage homePage)
        {
            //Уникальный текст поста 
            var postText = HelperMethodsCore.GetDateTimeSalt() + "_post";

            //Уникальный текст первого комментария
            var firstComment = HelperMethodsCore.GetDateTimeSalt() + "_comment1";

            //Уникальный текст второго комментария
            var secondComment = HelperMethodsCore.GetDateTimeSalt() + "_comment2";

            //Подготовка
            //Открываем новости
            var newsPage = homePage.SideMenu.OpenNews();
            newsPage
            //Открываем форму создания поста
                .OpenAddPostForm()
            //Выкладываем пост
                .CreatePost(postText);
            
            //Оставляем первый комментарий
            //Перейти в ленту
            var newsPost = newsPage
            //Найти пост в ленте
                .FeedSearch(postText);
            newsPost
            //Открыть комментарии
                .OpenCommentSection()
            //Пишем текст комментария
                .FillCommentText(firstComment)
            //Отправляем комментарий
                .SendComment();

            //Авторизировываемся вторым юзером и открываем ленту новостей
            var regularEmployee = ExecutableTestCase.RunningTestCase.CreatePortalTestUser(false);
            var driver2 = DriverActionsWeb.CreateNewDriver();
            var homePage2 = new WebLoginPage(ExecutableTestCase.RunningTestCase.TestPortal, driver2).Login(regularEmployee);
            homePage2.SideMenu.OpenNews()
            //Найти комментарий в ленте
                .FeedSearch(postText)
            //Открыть комментарии
                .OpenCommentSection()
            //Нажать на кнопку ответа на комментарий
                .CommentReply()
            //Пишем текст комментария
                .FillCommentText(secondComment)
            //Отправляем комментарий
                .SendComment();
            driver2.Close();

            //Рефрешнуть страницу
            DriverActionsWeb.Refresh();
            //Проверить что ответ на комментарий создан
            newsPost
            //Проверить что ответ существует
                .AssertCommentReply(secondComment);
        }
    }
}
