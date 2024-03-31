using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Mobile;
using OpenQA.Selenium.DevTools.V120.CacheStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace atFrameWork2.TestEntities
{
    public class Bitrix24CRMDeal
    {
        public Bitrix24CRMDeal(string title = "")
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public MobileCRMDealPage back()
        {
            //нажмем кнопку "назад"
            var GoBackBtn = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/pageTitle\" and @text=\"Меню\"]", "Выход со страницы сделки");
            GoBackBtn.Click();

            //Если вылезет Push, сохраняем его
            var PushTitle = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/pageTitle\" and @text=\"Push CRM\"]", "Подпись Push CRM");

            bool isPushPresent = Waiters.WaitForCondition(() => PushTitle.WaitElementDisplayed(), 2, 6, $"Ожидание Push");

            if ( isPushPresent )
            {
                var SavePushBtn = new MobileItem("//android.widget.TextView[@text=\"Сохранить\"]", "Сохраняем PUSH");
                SavePushBtn.Click();
            }
            return new MobileCRMDealPage();

        }

        public MobileCRMDealPage Delete()
        {
            //Открыть параметры

            var RightUpSettingBtn = new MobileItem("(//android.widget.FrameLayout[@resource-id=\"com.bitrix24.android:id/dynamicRightButtonsContainer\"])[3]", "Открыть параметры");
            Waiters.WaitForCondition(() => RightUpSettingBtn.WaitElementDisplayed(), 2, 6,
               $"ожидание прогрузки");
            RightUpSettingBtn.Click();
            //Выбрать "удалить"
            var DeleteChoice = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/title\" and @text=\"Удалить сделку\"]", "Выбрать \"Удалить сделку\"");
            DeleteChoice.Click();
            var AcceptDeleteChoice = new MobileItem("//android.widget.Button[@resource-id=\"android:id/button2\"]", "Подтверждение удаления");
            AcceptDeleteChoice.Click();
            return new MobileCRMDealPage();


        }

    }
}
