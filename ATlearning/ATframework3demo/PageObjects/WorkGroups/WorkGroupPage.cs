
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.NewsPost;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.DevTools.V120.IndexedDB;
using OpenQA.Selenium.DevTools.V85.IndexedDB;

namespace ATframework3demo.PageObjects.WorkGroups
{
    /// <summary>
    /// Текущая страница схода по функционалу со страницей News page, так что некоторые методы, приведенные здесь -
    /// переиспользование методов из NewsPage
    /// </summary>
    public class WorkGroupPage
    {   //Клик в Написать сообщение
        public ProjectPostForm AddPost()
        {
            NewsPage IsLikeNewsPage = new NewsPage();
            IsLikeNewsPage.AddPost();
            return new ProjectPostForm();
        }
        //Выход из фрейма, закрытие слайдера
        public WorkGroupsPage CloseSlider()
        {
            WebItem.DefaultDriver.SwitchTo().ParentFrame();
            WebItem CloseBtn = new WebItem("" +
                //находим текущию активную панель
                "//div[@class=\"side-panel side-panel-overlay side-panel-overlay-open\"]" +
                //находим потомка соотвествуюшего кнопке закрытия текущего слайдера
                "//descendant::div[@class =\"side-panel-label-icon side-panel-label-icon-close\"]"
                , "Кнопка закрытия текущего оверлея");
            CloseBtn.Click();
                    
            
            return new WorkGroupsPage();
        }
        //Поиск на странице публикации по заданной строке
        public bool PostByTextExist(string postText)
        {
            NewsPage ThisScreen = new NewsPage();
            NewsBlock NewsWithText = ThisScreen.FindNewsByString(postText);
            return NewsWithText.WaitElementDisplayed();

        }

        public WorkGroupPage Search(string sampletext)
        {
            NewsPage ThisScreen = new NewsPage();
            ThisScreen.Search(sampletext);
            return this;
        }
    }
}