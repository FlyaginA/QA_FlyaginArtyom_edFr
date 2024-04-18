using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Mobile;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.TestCases.Mobile
{
    public class Case_Mobile_CRM_Deal : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("CRM_Создание сделки", mobileHomePage => Create_Deal(mobileHomePage)));
            return caseCollection;
        }

        void Create_Deal(MobileHomePage homePage)
        {
            //обработка сценария "знакомство с Битрикс24"
            var Skip = new MobileItem("//android.widget.TextView[@text=\"Далее\"]", "Кнопка 'Далее'");
            bool isWelcomePresent = Waiters.WaitForCondition(() => Skip.WaitElementDisplayed(), 2, 6,
               $"ожидание кнопки далее");
            while (isWelcomePresent)
            {
                Skip.Click();
                isWelcomePresent = Waiters.WaitForCondition(() => Skip.WaitElementDisplayed(), 2, 6,
               $"Ожидание появления кнопки далее");
                if (!isWelcomePresent)
                {
                    Skip = new MobileItem("//android.widget.TextView[@text=\"Начать работу\"]", "Кнопка 'Начать работу'");
                    Skip.Click();
                    break;
                }
            }


            string Name_Deal = "AutoTestDeal";
            var TestCRMDeal = new Bitrix24CRMDeal(Name_Deal);

            bool IsDealPresent = homePage.TabsPanel
            //Войти в раздел "еще"
            .More()
            //Выбрать CRM
            .CRM()
            //Кнопка "создать"
            .CreateDeal(TestCRMDeal)
            //кликнуть "Вернуться"
            .back()
            //проверить наличие
            .IsDealPresent(TestCRMDeal);

            if (!IsDealPresent)
            {
                Log.Error($"Созданная сделка с названием \"{Name_Deal}\" не отображается");
            }
        }
    }


}