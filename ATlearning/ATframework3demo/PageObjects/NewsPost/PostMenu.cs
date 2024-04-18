using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.NewsPost
{
    public class PostMenu : WebItem
    {
        public PostMenu(string xpathLocator, string description) : base(xpathLocator, description)
        {
            
        }

        

        internal PortalHomePage Delete()
        {
            //выбрать пункт "удалить" из открывшегося меню
            new WebItem($"{XPathLocators[0]}/descendant::span[@class=\"menu-popup-item-text\" and text()=\"Удалить\"]/parent::*", "пункт - Удалить")
                .Click();
            //нажмем "ОК" во всплывшем окне
            DefaultDriver.SwitchTo().Alert().Accept();
            //Перезагрузим страницу
            WebDriverActions.Refresh();
            return new PortalHomePage();
        }
    }
}