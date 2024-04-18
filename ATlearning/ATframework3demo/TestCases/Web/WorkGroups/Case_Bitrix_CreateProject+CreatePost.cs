using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.WorkGroups;


namespace ATframework3demo.TestCases.Web.WorkGroups
{
    public class Case_Bitrix_CreateProject_CreatePost : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("создание проекта + пост в ленту проекта", homePage => CreateProjectCreatePost(homePage)));
            return caseCollection;
        }

        void CreateProjectCreatePost(PortalHomePage homePage)
        {
            //задаем название нашему проекту
            string WorkGroupName = "Test" + DateTime.Now.Ticks;
            //Задаем текст сообщения, которое будем отправлять на странице проекта
            string PostText = "TestPost" + DateTime.Now.Ticks;
            bool WorkGroupWasCreated =
            homePage
                //Перейти в раздел "группы"
                .LeftMenu
                .WorkGroups()
            //Создать новую сущность
                .ProjectAddButton()
            //Выбрать "проект", следующий шаг
                .ChooseProject()
                .NextStep()
            //Вписать название, следующий шаг
                .EnterNameProject(WorkGroupName)
                .NextStep()
            //выбрать открытый, следующий шаг
                .ChooseOpen()
                .NextStep()
            //не выбирать участников, перейти на следующий шаг
                .NextStep()
            //выбрать окно написания поста
                .AddPost()
            //написать текст тестового сообщения
                .EnterText(PostText)
            //отправить сообщение
                .SendPost()
            //Закрыть Слайдер
                .CloseSlider()
            //Проверить наличие проекта с нашим названием
                .Search(WorkGroupName)
                .Assert_WorkGroupExistByName(WorkGroupName);
            if (!WorkGroupWasCreated)
            {
                Log.Error("Проект с заданным названием не отображается");
            }
            //проверить наличие созданного поста
            bool ProjectPostExists =
                new WorkGroupsPage()
                    //выберем в списке элемент соответстующий нашему названию
                    .ChooseWorkGroupItem(WorkGroupName)
                    //открыть проект с нашим названием
                    .OpenWorkGroup()
                    //проверить наличие созданного поста
                    .Search(PostText)
                    .PostByTextExist(PostText);

            if (!ProjectPostExists)
            {
                Log.Error("Пост с заданным текстом не отображается");
            }
        }
    }
}
