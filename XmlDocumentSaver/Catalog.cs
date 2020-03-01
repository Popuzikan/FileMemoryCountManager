using System.Collections.Generic;

namespace FileMemoryCountManager.XmlDocumentSaver
{

        //
        // Сводка:
        //     Представляет каталог для ХML документа
   class Catalog<T> where T : struct
   {
        public List<T> Files { get; set; }

        public Catalog()
        {
            Files = new List<T>();
        }
   }
   
}
