using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.WorkGroups;
using ATframework3demo.TestEntities;


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
            //задаем название нашему проекту и создадим его сущность
            TestWorkgroup workgroup = new TestWorkgroup("Test" + DateTime.Now.Ticks);
            //Задаем текст сообщения, которое будем отправлять на странице проекта и создадим его сущность
            TestPost post = new TestPost("TestPost" + DateTime.Now.Ticks);
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
                .EnterNameProject(workgroup.WorkGroupName)
                .NextStep()
            //выбрать открытый, следующий шаг
                .ChooseOpen()
                .NextStep()
            //не выбирать участников, перейти на следующий шаг
                .NextStep()
            //выбрать окно написания поста
                .AddPost()
            //написать текст тестового сообщения
                .EnterText(post.PostText)
            //отправить сообщение
                .SendPost()
            //Закрыть Слайдер
                .CloseSlider()
            //Проверить наличие проекта с нашим названием
                .Search(workgroup.WorkGroupName)
                .ChooseWorkGroupItem(workgroup.XPath)
                .WaitElementDisplayed();
            if (!WorkGroupWasCreated)
            {
                Log.Error("Проект с заданным названием не отображается");
            }
            //проверить наличие созданного поста
            bool ProjectPostExists =
                new WorkGroupsPage()
                    //выберем в списке элемент соответстующий нашему названию
                    .ChooseWorkGroupItem(workgroup.XPath)
                    //открыть проект с нашим названием
                    .OpenWorkGroup()
                    //проверить наличие созданного поста
                    .Search(post.PostText)
                    .PostByTextExist(post.PostText);

            if (!ProjectPostExists)
            {
                Log.Error("Пост с заданным текстом не отображается");
            }
        }
    }
}
