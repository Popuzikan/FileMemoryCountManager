using FileMemoryCountManager.Clients;
using FileMemoryCountManager.SubSystemsClass;
using FileMemoryCountManager.XmlDocumentSaver;

namespace FileMemoryCountManager.ProgrammCompiller
{
        //
        // Сводка:
        //     Представляет непосредственно сам Фасад приложения
        //     объединяет все необходимые классы приложения
    class AppCreator
    {
        private FileManager _fileManager;

        private readonly Client _client;

        private readonly XmlProvider _xmlProvider;

        private readonly ServiceProvider _serviceProvider;

        public AppCreator(Client client, ServiceProvider serviceProvider, XmlProvider xmlProvider)
        {
            _client = client;
            _serviceProvider = serviceProvider;
            _xmlProvider = xmlProvider;
        }

        //
        // Сводка:
        //      Компилятор основных частей приложения
        public void Compile()
        {
            _fileManager = new FileManager(_serviceProvider.FindFilesInDirectory( _client.SelectFolderForMemoryCounting()), _xmlProvider);

            _fileManager.ShowFoundData();

            _fileManager.ReadSumBytesInSearchFilesAsync();
        }
    }
}
