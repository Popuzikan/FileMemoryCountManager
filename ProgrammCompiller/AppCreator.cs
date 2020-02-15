using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FileMemoryCountManager.Clients;
using FileMemoryCountManager.SubSystemsClass;
using FileMemoryCountManager.XmlDocumentSaver;


namespace FileMemoryCountManager.ProgrammCompiller
{
    class AppCreator
    {

        private Client _client;

        private FileManager _fileManager;

        private ServiceProvider _serviceProvider;

        private XmlProvider _xmlProvider;

        public AppCreator(Client client, ServiceProvider serviceProvider, XmlProvider xmlProvider)
        {
            _client = client;
            _serviceProvider = serviceProvider;
            _xmlProvider = xmlProvider;
        }


        public void Compile()
        {
            _fileManager = new FileManager(_serviceProvider.FindFilesInDirectory(_client.SelectFolderForMemoryCounting()), _xmlProvider);

            _fileManager.Show();

            _fileManager.ReadSumBytesInSearchFilesAsync();
        }

    }
}
