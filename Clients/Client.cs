using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileMemoryCountManager.Clients
{
    class Client
    {
        private readonly FolderBrowserDialog folderBrowser;

        public Client()
        {
            folderBrowser = new FolderBrowserDialog();
        }

        public DirectoryInfo SelectFolderForMemoryCounting()
        {
            if (folderBrowser.ShowDialog().Equals(DialogResult.OK))
                return string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) ? SelectFolderForMemoryCounting():new DirectoryInfo(folderBrowser.SelectedPath);
          
            else
                return SelectFolderForMemoryCounting();
        }
    }
}
