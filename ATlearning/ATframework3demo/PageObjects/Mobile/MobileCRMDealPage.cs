using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Mobile
{
    public class MobileCRMDealPage
    {
        /// <summary>
        /// Страница CRM со сделками
        /// </summary>
       

        public Bitrix24CRMDeal CreateDeal(Bitrix24CRMDeal deal)
        {
            //Сначала проверяем наличие сущности с названием создаваемой, если такая присутствует, удаляем
            if (IsDealPresent(deal))
            {
                new MobileItem($"//android.widget.TextView[@text=\"{deal.Title}\"]",
                $"Заголовок сделки с текстом {deal.Title}").Click();
                new Bitrix24CRMDeal().Delete();
            }

            //Выбрать создание Сделки
            var CreateBtn = new MobileItem("//android.widget.FrameLayout[@resource-id=\"com.bitrix24.android:id/layout_root\"]" +
                "/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]" +
                "/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup", "Кнопка создания новой сущности");
            CreateBtn.Click();
            
            //Выбрать поле "названия"
            var CreateDealBtn = new MobileItem("//android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]", "Выбор создания сделки");
            CreateDealBtn.Click();

            //Вписать название
            
            var NameField = new MobileItem("//android.widget.TextView[@text=\"Название\"]", "Открытие поля ввода названия Сделки");
            NameField.Click();
            NameField = new MobileItem("//android.widget.EditText[@text=\"Сделка #\"]", "Поле ввода названия Сделки");
            NameField.SendKeys($"{deal.Title}");
            

            //Подтвердить создание Сделки
            var CreateEntity = new MobileItem("//android.widget.TextView[@text=\"Создать\"]", "Подтверждение создания новой сущности");
            CreateEntity.Click();

            //кликнуть "Вернуться"
            //save pushCRM step
            return deal;
        }

        public bool IsDealPresent(Bitrix24CRMDeal testCRMDeal)
        {
            var DealName = new MobileItem($"//android.widget.TextView[@text=\"{testCRMDeal.Title}\"]",
                $"Заголовок сделки с текстом {testCRMDeal.Title}");

            bool isDealPresent = Waiters.WaitForCondition(() => DealName.WaitElementDisplayed(), 2, 6,
                $"Ожидание появления сделки '{testCRMDeal.Title}' в списке сделок");
            return isDealPresent;
        }
    }
}