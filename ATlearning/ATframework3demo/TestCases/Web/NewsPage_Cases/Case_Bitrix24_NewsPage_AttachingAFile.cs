using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Drive;

namespace ATframework3demo.TestCases.Web.NewsPage_Cases
{
    public class Case_Bitrix24_NewsPage_AttachingAFile : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Прикрепление файла к сообщению в новостной ленте (>5Mb)", homePage => AttachAFile(homePage)));
            return caseCollection;
        }

        void AttachAFile(PortalHomePage homePage)
        {
            //укажем название и путь загружаемого файла
            string filename = "how developers think.MP4";
            string filepath = "D:\\bitrix\\lab2(auto test)\\ConsoleApp1\\how developers think.MP4";

            //сначала стоит проверить наличие файла, аналогичного загружаемому
            if (new NewsPage().PrerequisiteCaseBitrix24NewsPageAttachingFile(filename) == false)
            {

                homePage
                    .NewsPage
                    //находим пост с таким файлом
                    .FindNewsByString(filename)
                    //открываем меню поста
                    .OpenPostMenu()
                    //удаляем пост с таким файлом

                    .Delete();
                //удаляем из диска
            }
            homePage
                //проверяем отсутствие загружаемого файла на диске 
                //открываем левое меню
                .LeftMenu
                //переходим в диск
                .Drive()
                //выбираем папку "загруженные файлы"
                .DownloadFiles()
                //открываем эту папку
                .OpenMenu()
                .Open();

            if (new MyDrive().PrerequisiteCaseBitrix24NewsPageAttachingFile(filename) == true)
            {
                homePage
                    .MyDrive
                //находим файл с названием файла
                    .FindElementByString(filename)
                    //открываем меню
                    .OpenMenu()
                    //удалить файл
                    .Delete()
                    //подтверждение
                    .Accept();
                //обновление страницы
                WebDriverActions.Refresh();
                //возвращаемся на главную страницу
                homePage.LeftMenu.OpenNews();
            }
            //возвращаемся на главную страницу
            homePage
                .LeftMenu
                .OpenNews();
            //Появляемся на главной странице портала
            homePage
                .NewsPage
                //открыть написание нового поста
                .AddPost()
                //включить в панели инструментов прикрепление файла
                .Toolbar_NewPost
                .AttachFile()
                //прикрепить файл
                .fileInput
                .UploadFile(filepath);


            //проверить что прикрепленный файл существует
            homePage
                .NewsPage
                .PostForm
                .Assert_AttachedFiles()

                //Опубликовать пост
                .SendPost();
            //Обновить страницу, проверить наличие загруженного файла на странице
            WebDriverActions.Refresh();
            //проверить наличие поста с прикрепленным файлом
            homePage
                .NewsPage
                .Assert_Case_Bitrix24_NewsPage_AttachingFile(filename);
















        }
    }
}
