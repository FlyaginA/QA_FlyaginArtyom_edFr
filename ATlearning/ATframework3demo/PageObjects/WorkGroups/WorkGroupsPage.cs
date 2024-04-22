

using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.WorkGroups.CreateSteps;
using Microsoft.AspNetCore.Components.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.DevTools.V121.IndexedDB;

namespace ATframework3demo.PageObjects.WorkGroups
{
    public class WorkGroupsPage
    {
        //Клик в кнопку создания новой групы/проекта
        public WorkGroups_Create_Step1 ProjectAddButton()
        {
            new WebItem("//a [@id = \"projectAddButton\"]", "Кнопка создания новой сущности(проекта/группы)")
                .Click();
            new WebItem("//iframe [@src = \"/company/personal/user/1/groups/create/?IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER\"]"
                , "переключение на фрейм создания проекта").SwitchToFrame();
            
            return new WorkGroups_Create_Step1();
        }


        //поиск по странице элемента типа WorkGroupItem названием по заданной строке и возврат этого  элемента
        public WorkGroupItem ChooseWorkGroupItem(string xpath)
        {
            WorkGroupItem OurChoose = new WorkGroupItem(xpath, "объект списка проектов/групп");
            return OurChoose;
        }
        //Использование функционала поиска по странице (Фильтр+Поиск)
        public WorkGroupsPage Search(string workGroupName)
        {
            WebItem SearchField = new WebItem("//input[@id = \"SONET_GROUP_LIST_search\"]", "Поле поиска");
            SearchField.WaitElementDisplayed(10);
            SearchField .Click();
            SearchField.SendKeys(workGroupName);
            SearchField.SendKeys(Keys.Enter);
            return this;
        }

    }
}