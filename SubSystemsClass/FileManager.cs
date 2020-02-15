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
        private byte[] _bytes;

        private FileStream [] _fileStream;

        private readonly IDictionary<string, string> _list;

        public FileManager(IDictionary<string,string> list)
        {
            if (list != null && !list.Count.Equals(0))
            {
                _list = list;
                _fileStream = new FileStream [list.Count];
            }
            else
                Console.WriteLine("List is empty");
        }

        public void ReadSumFilesInBytesAsync()
        {
            int counter = 0;
          
            foreach (var item in _list)
            {
                string ext = Path.GetExtension(item.Value);

                if (!string.IsNullOrEmpty(ext))
                {
                    _fileStream[counter] = File.OpenRead(item.Value);

                    _bytes = new byte[_fileStream[counter].Length];

                    _fileStream[counter].Read(_bytes, 0, _bytes.Length);           
                }
                ThreadPool.QueueUserWorkItem(GetByteResultForConsoles,_bytes);
            }          
        }

        public void GetByteResultForConsoles(object array)
        {
            byte[] mass;
            long sumResult = 0;
            if (array is Array)
            {
                mass = (byte [])array;
                foreach (var item in mass)
                         sumResult += item;

                Console.WriteLine($"Yo result {sumResult.ToString()}");
            }    
        }
        //private void GetByteResultForConsoles(IAsyncResult asyncResult)
        //{
        //    asyncStater = false;

        //    long sum = 0;

        //    (asyncResult.AsyncState as FileStream)?.Close();

        //    foreach (var item in _bytes)
        //              sum+=item;

        //    Console.WriteLine($"Bytes sum is readed => {sum.ToString()}");           
        //}


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
