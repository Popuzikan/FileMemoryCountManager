using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Collections.Generic;
using FileMemoryCountManager.XmlDocumentSaver;


namespace FileMemoryCountManager.SubSystemsClass
{
    class FileManager
    {
        private byte [] _bytes;

        private long _bytesSum;
             
        private Stream _streamer;

        private BufferedStream  _bufferedStream;

        private readonly IDictionary<string, string> _listDictinary;

        private readonly Catalog<XmlFile> _catalog;

        public FileManager(IDictionary<string,string> listDictinary)
        {
            if (listDictinary != null && !listDictinary.Count.Equals(0))
            {
                _listDictinary = listDictinary;
                _catalog = new Catalog<XmlFile>();
            }
            else
                Console.WriteLine("List is empty");  
        }

        public async void ReadSumBytesInSearchFilesAsync()
        {
            foreach (var pair in _listDictinary)
            {                
                if (!string.IsNullOrEmpty(Path.GetExtension(pair.Value)))
                {
                    _streamer = File.OpenRead(pair.Value);
                   
                    _bufferedStream = new BufferedStream(_streamer, (int)_streamer.Length);

                    _bytes = new byte[_bufferedStream.Length];

                    await _bufferedStream.ReadAsync(_bytes, 0, _bytes.Length);

                    await Task.Factory.StartNew(fileName =>
                    {
                        _bytesSum = _bytes.Sum(n => (long)n);

                        _catalog.Files.Add(new XmlFile(fileName.ToString(), _bytesSum));

                        Console.WriteLine($"\nFile {fileName.ToString()} " +
                            $"result sum bytes memory => {_bytesSum.ToString()}");
                       

                    }, Path.GetFileName(pair.Value));
                }         
            }          
        }
  
        public void Show()
        {
            if (_listDictinary.Count!=0)
            {
                foreach (var pair in _listDictinary)
                {
                    if (string.IsNullOrWhiteSpace(Path.GetExtension(pair.Value)))
                        Console.WriteLine($"{pair.Key} Catalog => {Path.GetDirectoryName(pair.Value)}");

                    else
                        Console.WriteLine($"{pair.Key} File => {Path.GetFileName(pair.Value)}");
                }
            }
            else
                Console.WriteLine("Files was not found");
           
        }
    }
}
