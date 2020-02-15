using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FileMemoryCountManager.SubSystemsClass
{
    class FileManager
    {
        private byte [] _bytes;

        private Stream _streamer;

        private BufferedStream  _bufferedStream;

        private readonly IDictionary<string, string> _list;

        public FileManager(IDictionary<string,string> list)
        {
            if (list != null && !list.Count.Equals(0))
                _list = list;
            else
                Console.WriteLine("List is empty");
        }

        public async void ReadSumFilesInBytesAsync()
        {
            foreach (var item in _list)
            {
                string ext = Path.GetExtension(item.Value);

                if (!string.IsNullOrEmpty(ext))
                {
                    _streamer = File.OpenRead(item.Value);
                   
                    _bufferedStream = new BufferedStream(_streamer, (int)_streamer.Length);

                    _bytes = new byte[_bufferedStream.Length];

                    await _bufferedStream.ReadAsync(_bytes, 0, _bytes.Length);

                    await Task.Factory.StartNew(GetByteResultForConsoles, item.Key);

                }         
            }              
        }

        private void GetByteResultForConsoles(object sender)
        {
           long sumResult = 0;
                    
           foreach (var item in _bytes)
                  sumResult += item;

               Console.WriteLine($"File {sender.ToString()} result sum bytes memory => {sumResult.ToString(),20}");
     
        }
    
        public void Show()
        {
            foreach (var pair in _list)
            {
                if (string.IsNullOrWhiteSpace(Path.GetExtension(pair.Value)))
                    Console.WriteLine($"{pair.Key} Catalog => {Path.GetDirectoryName(pair.Value)}");
                else
                    Console.WriteLine($"{pair.Key} File => {Path.GetFileName(pair.Value)}");       
            }
        }
    }
}
