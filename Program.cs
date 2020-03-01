﻿using System;
using FileMemoryCountManager.ProgrammCompiller;
using FileMemoryCountManager.XmlDocumentSaver;
using FileMemoryCountManager.Clients;
using FileMemoryCountManager.SubSystemsClass;

namespace FileMemoryCountManager
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Console.Title = "FileMemoryCounter";

            string pathXmlFile = "XmlFileInfo.xml";

            AppCreator appCreator = new AppCreator(new Client(),new ServiceProvider(), new XmlProvider(pathXmlFile));

            StartAplication(appCreator);

            Console.ReadKey();
        }

        static void StartAplication(AppCreator creator)
        {
                creator?.Compile();   
        }
    }
}
