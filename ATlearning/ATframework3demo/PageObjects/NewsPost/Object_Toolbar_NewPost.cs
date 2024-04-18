using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using ATframework3demo.PageObjects;
using ATframework3demo.TestCases.Web.NewsPage_Cases;

namespace ATframework3demo.PageObjects.NewsPost
{
    public class Object_Toolbar_NewPost : WebItem
    {
        
        public Object_Toolbar_NewPost(
            string xpathLocator = "//div[@id=\"microblog-form\"]/descendant::div[@class=\"main-post-form-toolbar-buttons-container\"]"
            , string description = "Панель инструментов для нового поста") 
            : base(xpathLocator, description)
        {
        }

        public NewsPostForm AttachFile()
        {
            new WebItem($"{XPathLocators[0]}/descendant::div[@data-id = \"file\"]", "Открытие панели прикрепления файла").Click();

            return new NewsPostForm();
        }


    }
}
