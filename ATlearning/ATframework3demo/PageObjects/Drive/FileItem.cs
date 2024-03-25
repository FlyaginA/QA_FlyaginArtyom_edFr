using OpenQA.Selenium;
using atFrameWork2;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Drive;

namespace ATframework3demo.PageObjects.Drive
{
    public class FileItem : WebItem
    {
        public FileItem(string xpathLocator, string description) : base(xpathLocator, description)
        {
        }

        public File_menu_popup OpenMenu()
        {
            string dataId = GetAttribute("data-id");
            new File_menu_popup($"{XPathLocators[0]}/descendant::div[@class=\"disk-folder-list-item-action\"]", "кнопка открытия контекстного меню")
                .Click();
            return new File_menu_popup($"//div[@id=\"popup-window-content-menu-popup--disk-folder-list-item-action-menu{dataId}\"]", "контекстное меню");
        }


    }
}
