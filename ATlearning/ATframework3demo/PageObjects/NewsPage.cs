using ATframework3demo.PageObjects.NewsPost;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework.LogTools;

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

        //проверяет отсутствие загружаемого в носотную ленту файла если присутствует, возвращает False
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
            
            if (assert = false)
            {
                Log.Error("File was not attached");
            }
            else
            {
                Log.Info("File was attached");
            }
            return assert ;
        }

        

        
        //поиск новости по строке
        internal NewsBlock FindNewsByString(string SampleText)
        {
            //Найти объект в котором присутствует строка
            NewsBlock NewsFormWithText = new NewsBlock($"//*[text()=\"{SampleText}\"]" +
            //перейти на родительский объект новостного блока
                $"/ancestor::div[@class=\"feed-post-block feed-post-block-files feed-post-block-separator feed-post-block-pin feed-post-block-has-bottom feed-post-block-short\"]" +
                $"", "новостной блок содержащий заданную строку");
            return NewsFormWithText;


        }









    }
}
