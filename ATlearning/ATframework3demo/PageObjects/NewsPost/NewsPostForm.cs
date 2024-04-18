using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using ATframework3demo.PageObjects;

namespace ATframework3demo.PageObjects.NewsPost
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm:WebItem
    {
        public BitrixMagicFileInput fileInput => new BitrixMagicFileInput();
        public Object_Toolbar_NewPost Toolbar_NewPost => new Object_Toolbar_NewPost();
       
        public NewsPostForm(string xpathLocator = "//div[@id=\"microblog-form\"]", 
            string description = "локатор контейнера редактора постов") : base(xpathLocator, description)
        {
        }

        public bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            bool isRecipientPresent = Waiters.WaitForCondition(() => recipientsArea.AssertTextContains(recipientName, default), 2, 6,
                $"Ожидание появления строки '{recipientName}' в '{recipientsArea.Description}'");
            return isRecipientPresent;
        }



        //Опубликовать пост, нажав на кнопку "отправить"
        internal NewsPage SendPost()
        {
            
            new WebItem($"{XPathLocators[0]}/descendant::span[@id=\"blog-submit-button-save\"]", "кнопка публикации")
                .Click();
            return new NewsPage();
        }
        
        public NewsPostForm Assert_AttachedFiles()
        {

            Log.Info("Attached files:");
            int i = 1;
            new WebItem("//div[@class = \"ui-tile-uploader-item ui-tile-uploader-item--complete\"]",
                "готовая загрука").WaitElementDisplayed(60);
            while ( new WebItem($"{XPathLocators[0]}/descendant::*[@class=\"ui-tile-uploader-items\"]/descendant::*[@class = \"ui-tile-uploader-item-name-box\"][{i.ToString()}]"
            ,"локатор очередного прикрепленного вложения").WaitElementDisplayed(10))
            {
                Log.Info(new WebItem($"{XPathLocators[0]}/descendant::*[@class=\"ui-tile-uploader-items\"]" +
                    $"/descendant::*[@class = \"ui-tile-uploader-item-name-box\"][{i.ToString()}]"
                    , "").GetAttribute("title"));
                i++;
            }
            if (i == 1)
            {
                Log.Error("File was not attached!!!");
            }
            return this;
        }
        //Ввод текста сообщения
        public NewsPostForm EnterText(string text)
        {
            //входим в фрейм текстового поля
            WebItem ThisScreen = new WebItem("//iframe [@class = \"bx-editor-iframe\"]", "Фрейм текствого поля");
            ThisScreen.SwitchToFrame();
            new WebItem("//body[@contenteditable = \"true\"]", "поле ввода текста").SendKeys(text);
            WebItem.DefaultDriver.SwitchTo().ParentFrame();
            return this;
        }
    }
}
