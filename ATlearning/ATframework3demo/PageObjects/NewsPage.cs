using ATframework3demo.PageObjects.NewsPost;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {

        public NewsPostForm AddPost()
        {
            //Клик в Написать сообщение
            var btnPostCreate = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click();
            return new NewsPostForm();
        }

        internal bool Assert_Case_Bitrix24_NewsPage_AttachingAFile()
        {
            //использовать поиск по странице, найти название загруженного файла
            throw new NotImplementedException();
        }

        internal NewsPostForm AttachFile(string filepath)
        {
            //использовать BitrixMagicFileInput, Прикрепить файл
            throw new NotImplementedException();

        }


        }
    }
}
