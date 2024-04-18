using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.WorkGroups.CreateSteps
{
    /// <summary>
    /// Создание проекта происходит в 4 шага
    /// шаг 4-ый
    /// </summary>
    public class WorkGroups_Create_Step4 
    {
        public WorkGroupPage NextStep()
        {
            WorkGroups_Create_Step1 ThisScreen = new WorkGroups_Create_Step1();
            ThisScreen.NextStep();
            //этот шаг завершающий, после создания новой сущности, будет открыт слайдер с отображением этой сущности.
            //переключимся на него для дальнейшей работы
            WebItem.DefaultDriver.SwitchTo().DefaultContent();
            new WebItem("// div [@class = \"side-panel-content-container bitrix24-group-slider-content\"]//descendant::iframe[@class = \"side-panel-iframe\"]",
                "Фрейм с окном проекта").SwitchToFrame();
            return new WorkGroupPage();
        }
    }
}