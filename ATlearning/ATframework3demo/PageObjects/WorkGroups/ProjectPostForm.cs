

using ATframework3demo.PageObjects.NewsPost;

namespace ATframework3demo.PageObjects.WorkGroups
{
    /// <summary>
    /// Данный объект схожий по функционалу с объектом NewsPostForm,
    /// так что тут используется переиспользование методов.
    /// </summary>
    public class ProjectPostForm
    {
        //ввод текста сообщения
        public ProjectPostForm EnterText(string postText)
        {
            NewsPostForm ThisScreen = new NewsPostForm();
            ThisScreen.EnterText(postText);
            return this;
        }
        //Опубликовать пост, нажав на кнопку "отправить"
        public WorkGroupPage SendPost()
        {
            NewsPostForm ThisScreen = new NewsPostForm();
            ThisScreen.SendPost();
            return new WorkGroupPage();
        }
    }
}