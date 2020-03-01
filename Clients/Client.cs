using System;
using System.IO;
using System.Windows.Forms;

namespace FileMemoryCountManager.Clients
{
    class Client
    {
        //
        // Сводка:
        //        Представляет доступ клиента к проводнику
        private readonly FolderBrowserDialog folderBrowser;

        public Client()
        {
            folderBrowser = new FolderBrowserDialog();
        }

        //
        // Сводка:
        //       Метод для вызова проводника
        //       позволяет выбрать пользователю папку для поиска файлов
        public DirectoryInfo SelectFolderForMemoryCounting()
        {
            Console.WriteLine("\tSelect the folder you need to search for files");
            Console.WriteLine(new string('-',100));

            if (folderBrowser.ShowDialog().Equals(DialogResult.OK))
                return string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) ? SelectFolderForMemoryCounting():new DirectoryInfo(folderBrowser.SelectedPath);
          
            else
                return SelectFolderForMemoryCounting();
        }
    }
}
