
using OpenQA.Selenium;
using atFrameWork2.SeleniumFramework;


namespace ATframework3demo.PageObjects.Drive
{
    internal class Folder : WebItem
    {
        public Folder(string xpathLocator, string description) : base(xpathLocator, description)
        {
        }

        public Folder_menu_popup OpenMenu()
        {
            new Folder_menu_popup($"{XPathLocators[0]}/descendant::*[@class=\"disk-folder-list-item-action\"]", "кнопка открытия контекстного меню")
                .Click();
            return new Folder_menu_popup($"//div[@id=\"popup-window-content-menu-popup--disk-folder-list-item-action-menu95\"]", "контекстное меню");


        //на выход сразу панель взаимодействия с файлом

        }
    }
}