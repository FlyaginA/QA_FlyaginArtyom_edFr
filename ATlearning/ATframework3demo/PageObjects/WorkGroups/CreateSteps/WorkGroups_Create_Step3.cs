

using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.WorkGroups.CreateSteps
{
    /// <summary>
    /// Создание проекта происходит в 4 шага
    /// шаг 3-ий
    /// </summary>
    public class WorkGroups_Create_Step3
    {
        //выбор уровня конфидециальности "открытый"
        public WorkGroups_Create_Step3 ChooseOpen()
        {
            new WebItem("//div [@class = \"socialnetwork-group-create-ex__group-selector--logo --access-open\"]",
                "окно с выбором \"Открытого\" уровня конфидециальности").Click();
            return this;
        }
        //Переход на следующий шаг
        public WorkGroups_Create_Step4 NextStep()
        {
            WorkGroups_Create_Step1 ThisScreen = new WorkGroups_Create_Step1();
            ThisScreen.NextStep();
            return new WorkGroups_Create_Step4();
        }
    }
}