using OpenQA.Selenium;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Drive
{
    public class Folder_menu_popup : WebItem
    {
        public Folder_menu_popup(string xpathLocator, string description) : base(xpathLocator, description)
        {
        }

        public MyDrive Open()
        {
            new WebItem("//span[@class =\"menu-popup-item-text\" and text() = \"Открыть\"]", "Кнопка открыть в контекстном меню").Click();
            return new MyDrive();
        }
        


    }
}
