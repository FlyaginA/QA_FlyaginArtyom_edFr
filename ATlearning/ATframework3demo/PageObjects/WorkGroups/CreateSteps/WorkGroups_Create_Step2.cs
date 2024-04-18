

using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.WorkGroups.CreateSteps
{
    /// <summary>
    /// Создание проекта происходит в 4 шага
    /// шаг 2-ой
    /// </summary>
    public class WorkGroups_Create_Step2
    {
        //Ввод имени новой сущности
        public WorkGroups_Create_Step2 EnterNameProject(string projectName)
        {
            new WebItem("//input [@id = \"GROUP_NAME_input\"]",
                "Поле ввода названия проекта").SendKeys(projectName);
            return this;
        }
        //перейти на следующий шаг
        public WorkGroups_Create_Step3 NextStep()
        {
            WorkGroups_Create_Step1 ThisScreen = new WorkGroups_Create_Step1();
            ThisScreen.NextStep();
            return new WorkGroups_Create_Step3();
        }
    }
}