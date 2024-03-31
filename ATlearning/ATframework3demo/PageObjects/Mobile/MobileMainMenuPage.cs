using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Mobile
{
    /// <summary>
    /// Главное Меню приложения
    /// </summary>
    public class MobileMainMenuPage
    {
        public MobileCRMDealPage CRM()
        {
            var CRM_Choice = new MobileItem("//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.bitrix24.android:id/list\"]/android.widget.LinearLayout[6]", "Кнопка перехода в раздел CRM");
            CRM_Choice.Click();

            return new MobileCRMDealPage();
        }
    }
}