using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.WorkGroups
{
    public class WorkGroupItem : WebItem
    {
        public WorkGroupItem(string xpathLocator, string description) : base(xpathLocator, description)
        {
        }
        //Открытие проекта/группы
        public WorkGroupPage OpenWorkGroup()
        {
            string xpath = XPathLocators[0];
            new WebItem($"{XPathLocators[0]}//descendant::a [@class = \"sonet-group-grid-name-text\"]", "Название Проекта").Click();
            new WebItem($"//iframe[@src = \"/workgroups/group/{GetAttribute("data-id")}/?IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER\"]", "Переключение на фрейм")
                .SwitchToFrame();
            return new WorkGroupPage();
        }
    }
}