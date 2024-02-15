using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Mobile;

public class MobileLoginPage : BaseLoginPage
{
    public MobileLoginPage(PortalInfo portal) : base(portal)
    {
    }
    
    public MobileHomePage Login(User admin)
    {
        var enterAddresBtn = new MobileItem("//android.widget.TextView[@content-desc='authFormEnterAddressButton']", 
            "Кнопка 'введите адрес'");
        var portalAddresField = new MobileItem("//android.widget.EditText[@content-desc='signInPortalInput']", 
            "Поле для ввода адреса портала");
        var loginField = new MobileItem("//android.widget.EditText[@content-desc='signInPortalFormPhoneInput']",
            "Поле для ввода логина");
        var pwdField = new MobileItem("//android.widget.EditText[@content-desc='passwordFormInput']", 
            "Поле для ввода пароля");
        var nextBtn = new MobileItem("//android.widget.EditText[@content-desc='passwordFormInput']", 
            "Кнопка 'Далее'");
        
        // переходим к форме ввода адреса портала
        enterAddresBtn.Click();
        Thread.Sleep(1000);
        
        // вводим адресс портала и дальше
        portalAddresField.SendKeys(portalInfo.PortalUri.ToString());
        nextBtn.Click();
        Thread.Sleep(1000);

        // вводим логин и дальше
        loginField.SendKeys(admin.Login);
        nextBtn.Click();
        Thread.Sleep(1000);
        
        // вводим пароль и дальше
        pwdField.SendKeys(admin.Password, logInputtedText: false);
        Thread.Sleep(1000);
        
        return new MobileHomePage();
    }
}