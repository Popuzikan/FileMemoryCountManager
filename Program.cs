﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileMemoryCountManager.Clients;
using FileMemoryCountManager.SubSystemsClass;

namespace FileMemoryCountManager
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var client = new Client();

            var provider = new ServiceProvider();
                       
            Console.ReadKey();
                        
            var findFIles =  provider.FindFilesInDirectory(client.SelectFolderForMemoryCounting());

            var fileManager = new FileManager(findFIles);

            fileManager.Show();

            fileManager.ReadSumFilesInBytesAsync();


            Console.ReadKey();
        }
    }
}