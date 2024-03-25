using OpenQA.Selenium;
using atFrameWork2.SeleniumFramework;



namespace ATframework3demo.PageObjects.Drive
{
    public class File_menu_popup : WebItem
    {
        public File_menu_popup(string xpathLocator, string description) : base(xpathLocator, description)
        {
        }

        public Delete_ConfrimMessage Delete()
        {
            new WebItem($"{XPathLocators[0]}/descendant::*[text()=\"Удалить\"]", "Кнопка удаления файла").Click();
            return new Delete_ConfrimMessage();
        }


    }
}