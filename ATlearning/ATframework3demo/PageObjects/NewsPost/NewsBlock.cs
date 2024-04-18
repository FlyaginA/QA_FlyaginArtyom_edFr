


using atFrameWork2.SeleniumFramework;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ATframework3demo.PageObjects.NewsPost
{
    public class NewsBlock : WebItem
    {
        private string PostId;
        private WebItem Menu;


        
        public NewsBlock(string xpathLocator, string description) : base(xpathLocator, description)
        {

            PostId = GetAttribute("data-livefeed-id");
            Menu = new WebItem($"//div[@id=\"feed-post-menuanchor-right-{PostId}\"]", "объект открывающий контекстное меню поста");
           
        }

        public PostMenu OpenPostMenu()
        {
            //Кликнуть по объекту открывающему меню
            Menu.Click();
            //найти объект меню и передать на выход
            return new PostMenu($"//div[@id=\"popup-window-content-menu-popup-blog-post-{PostId}\"]", "объект контекстного меню поста");
        }
    }
}
