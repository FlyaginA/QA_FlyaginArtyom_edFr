using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases.NewsPage_Cases
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
            string filepath = "SomePath";
            homePage
                .NewsPage
                //прикрепить файл
                .AttachFile(filepath)
                //Опубликовать пост
                .SendPost()
            //Обновить страницу, проверить наличие загруженного файла на странице
                .Assert_Case_Bitrix24_NewsPage_AttachingAFile()











        }
    }
}
