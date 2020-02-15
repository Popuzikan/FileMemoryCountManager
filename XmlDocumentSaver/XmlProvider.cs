using System;
using System.Xml;

namespace FileMemoryCountManager.XmlDocumentSaver
{
    class XmlProvider
    {
        // полный путь нахождения ХМL документа для записи
        private readonly string _pathNameXmlDoc;

        public XmlProvider(string pathNameXmlDoc)
        {
            _pathNameXmlDoc = pathNameXmlDoc;
        }

        // метод записи данных в ХML файл
        public void WriteXmlFile(Catalog<XmlFile> catalog)
        {
            // Создаем новый Xml документ.
            var _document = new XmlDocument();

            // Создаем Xml заголовок.
            var xmlDeclaration = _document.CreateXmlDeclaration("1.0", "UTF-8", null);

            // Добавляем заголовок перед корневым элементом.
            _document.AppendChild(xmlDeclaration);

            // Создаем корневой элемент
            var root = _document.CreateElement("catalog");

            // Получаем все файлы.
            foreach (var file in catalog.Files)
            {
                // Создаем элемент записи файла.
                var fileNode = _document.CreateElement("Files");

                // Создаем зависимые элементы.
                AddChildNode("Name", file.Name, fileNode, _document);
                AddChildNode("Memory", file.Memory.ToString(), fileNode, _document);

                // Добавляем запись информации о файле в каталог.
                root.AppendChild(fileNode);
            }

            // Добавляем новый корневой элемент в документ.
            _document.AppendChild(root);

            // Сохраняем документ.
            _document.Save(_pathNameXmlDoc);

            Console.WriteLine($"\n\tFiles are successfully written to the XML document { _pathNameXmlDoc} located in the root of the application");
            Console.WriteLine(new string('-',100));

            // локальный метод фича С# .NET_7.0
            void AddChildNode(string childName, string childText, XmlElement parentNode, XmlDocument doc)
            {
                var child = doc.CreateElement(childName);
                child.InnerText = childText;
                parentNode.AppendChild(child);
            }
        }
    }
}
