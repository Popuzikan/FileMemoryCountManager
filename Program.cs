using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           
            var appCreator = new AppCreator(new Client(), new ServiceProvider(), new XmlProvider("XmlFileInfo.xml"));

            StartAplication(appCreator);

            Console.ReadKey();
        }

        static void StartAplication(AppCreator creator)
        {
            creator?.Compile(); 
        }
    }
}
