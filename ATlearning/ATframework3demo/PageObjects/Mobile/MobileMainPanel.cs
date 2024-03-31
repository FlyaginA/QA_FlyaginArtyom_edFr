using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile
{
    /// <summary>
    /// Главная панель приложения
    /// </summary>
    public class MobileMainPanel
    {
        public MobileTasksListPage SelectTasks()
        {
            var tasksTab = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_title\" and @text=\"Tasks\"]",
                "Таб 'Задачи'");
            tasksTab.Click();

            return new MobileTasksListPage();
        }

        public MobileMainMenuPage More()
        {
            var moreTab = new MobileItem("//android.widget.LinearLayout[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_item_container\"]/android.widget.LinearLayout[4]", "Таб 'Ещё'");
            moreTab.Click();
            //кликаем дважды, т.к. один раз может перекинуть на предыдущую вкладку
            moreTab.Click();

            return new MobileMainMenuPage();
        }
    }
}