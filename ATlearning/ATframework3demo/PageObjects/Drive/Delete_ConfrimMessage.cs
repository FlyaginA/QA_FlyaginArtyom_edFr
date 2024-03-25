using OpenQA.Selenium;
using atFrameWork2.SeleniumFramework;


namespace ATframework3demo.PageObjects.Drive
{
    public class Delete_ConfrimMessage
    {
        public MyDrive Accept()
        {
            new WebItem("//span[@class=\"ui-btn ui-btn-success\"]", "кнопка принятия действия удаления файла").Click();
            return new MyDrive();
        }
    }
}