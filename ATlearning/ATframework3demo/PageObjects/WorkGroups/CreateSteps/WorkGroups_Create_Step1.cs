

using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.WorkGroups.CreateSteps
{
    /// <summary>
    /// Создание проекта происходит в 4 шага
    /// шаг 1-ый
    /// </summary>

    public class WorkGroups_Create_Step1
    {
        //выбор типа создаваемой сущности
        public WorkGroups_Create_Step1 ChooseProject()
        {
            new WebItem("//div [@class =\"socialnetwork-group-create-ex__group-selector socialnetwork-group-create-ex__type-preset-selector --active\"]"
                , "Выбор типа проекта \"Проект\"")
                .Click();
            return this;
        }
        //переход на следующий шаг
        public WorkGroups_Create_Step2 NextStep()
        {
            new WebItem("//button [@id =\"sonet_group_create_popup_form_button_submit\"]","Кнопка \"Продолжить\"")
                .Click();
            return new WorkGroups_Create_Step2();
        }
    }
}