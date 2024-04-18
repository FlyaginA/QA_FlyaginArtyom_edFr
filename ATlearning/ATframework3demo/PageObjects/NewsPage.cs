using ATframework3demo.PageObjects.NewsPost;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework.LogTools;
using System.Xml.XPath;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        public NewsPostForm PostForm => new NewsPostForm();

        public NewsPostForm AddPost()
        {
            //Клик в Написать сообщение
            var btnPostCreate = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click();
            return new NewsPostForm();
        }

        //проверяет отсутствие загружаемого в новостную ленту файла если присутствует, возвращает False
        public bool PrerequisiteCaseBitrix24NewsPageAttachingFile(string filename)
        {
            
            return !(new WebItem($"//a[@data-title=\"{filename}\"]", "элемент с указанным названием")
                .WaitElementDisplayed());
        }

        internal bool Assert_Case_Bitrix24_NewsPage_AttachingFile(string filename)
        {
            //Проверяет наличие загружаемого в новостную ленту файла. Если присутствует, возвращает True
            bool assert = (new WebItem($"//a[@data-title=\"{filename}\"]", "элемент с указанным названием")
                .WaitElementDisplayed());
            
            if (assert == false)
            {
                Log.Error("File was not attached");
            }
            else
            {
                Log.Info("File was attached");
            }
            return assert ;
        }

        //использование функционала поиска


        
        //поиск новости на экране
        public NewsBlock FindNewsByString(string SampleText)
        {
            //Найти объект в котором присутствует строка
            NewsBlock NewsFormWithText = new NewsBlock($"" +
                //Контейнер, содержащий в себе все сообщения новостной ленты
                $"//div [@id =\"log_internal_container\"]" +
                //Найти объект в котором присутствует строка
                $"//descendant::div[@class = \"feed-post-text\" and text()=\"{SampleText}\"]" +
                //перейти на родительский объект новостного блока
                $"/ancestor::div[@class = \"feed-item-wrap\"]", "новостной блок содержащий заданную строку");
            return NewsFormWithText;


        }

        public NewsPage Search(string sampletext)
        {
            //открытие окна фильтра и поиска
            WebItem FilterAndSearch = new WebItem("//input[ @placeholder = \"Фильтр + поиск\"]", "окно Фильтра и поиска");
            FilterAndSearch.Click();
            FilterAndSearch.SendKeys(sampletext);
            return this;
        }
    }
}
