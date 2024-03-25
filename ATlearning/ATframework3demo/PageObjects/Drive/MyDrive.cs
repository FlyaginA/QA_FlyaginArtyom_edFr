
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using ATframework3demo.PageObjects.Drive;

namespace ATframework3demo.PageObjects.Drive
{
    public class MyDrive
    {




        internal Folder DownloadFiles()
        {
            return new Folder("//a[@title = \"Загруженные файлы\"]/ancestor::*[@class = \"ui-grid-tile-item-content\"]",
                "Область папки \"Загруженные файлы\"");
        }

       public FileItem FindElementByString(string filename)
        {
            FileItem element = new FileItem($"//a[@title =\"{filename}\"]" +
                $"/ancestor::div[@class=\"ui-grid-tile-item\"]", "искомый по запросу элемент");
            return element;
        }

        public bool PrerequisiteCaseBitrix24NewsPageAttachingFile(string filename)
        {
            //проверяет наличие файла с названием на странице.
            //если файла нет , возвращается false
            return (new WebItem($"//a[@title = {filename}]", "элемент с указанным названием")
                .WaitElementDisplayed());
        }

        
    }
}
