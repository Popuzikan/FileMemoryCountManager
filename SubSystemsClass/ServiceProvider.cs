using System;
using System.IO;
using System.Collections.Generic;

namespace FileMemoryCountManager.SubSystemsClass
{
    //Сводка:
    /// <summary>
    /// Данный класс является поставщиком услуг.
    /// This class is a service provider.
    /// </summary>>

    class ServiceProvider
    {
        //
        // Сводка:
        //     Представляет счетчик найденных поддирректорий.
        private int countSubDirrectory;
        //
        // Сводка:
        //     Представляет счетчик найденных файлов 
        //        находящихся в определенной поддиректории
        private int countFindFiles;
        
        private bool isFirstAcive = false;  

        private IDictionary<string, string> _listDictinary;

        //
        // Сводка:
        //     Выполняет инициализацию нового экземпляра класса FileMemoryCountManager.SubSystemsClass.ServiceProvider
        //      создает экземпляр класса Dictionary<string, string>()
        //
        public ServiceProvider()
        {
            _listDictinary = new Dictionary<string, string>();
        }

        //
        // Сводка:
        //     Выполняет поиск папок и файлов для указанного объекта System.IO.DirectoryInfo 
        //     возвращает универсальную коллекцию в виде пар "Ключ-значение"
        //
        // Параметры:
        //   pathForFind
        //     Строка, содержащая путь, в котором происходит поиск
        //
        public IDictionary<string, string> FindFilesInDirectory(DirectoryInfo pathForFind)
        {
            if (pathForFind.Exists)
            {
                if (!isFirstAcive)
                {
                    _listDictinary.Add($"{(++countSubDirrectory).ToString()}.", pathForFind.FullName);
                    isFirstAcive = true;
                }

                countFindFiles = 0;

                foreach (var file in pathForFind.GetFiles("*"))
                        _listDictinary.Add($"{(countSubDirrectory).ToString()}.{(++countFindFiles).ToString()}", file.FullName);

                foreach ( var subDirrectory in pathForFind.GetDirectories())
                {
                    countFindFiles = 0;

                    _listDictinary.Add($"{(++countSubDirrectory).ToString()}.", subDirrectory.FullName);

                    FindFilesInDirectory(subDirrectory);
                }
            }
            else
                Console.WriteLine("Directory was not found");

            return _listDictinary;
        }
    }

}
