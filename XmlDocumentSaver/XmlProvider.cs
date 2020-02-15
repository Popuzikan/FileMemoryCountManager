using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileMemoryCountManager.XmlDocumentSaver
{
    class XmlProvider
    {
        private string _pathNameXmlDoc;

        public XmlProvider(string pathNameXmlDoc)
        {
            _pathNameXmlDoc = pathNameXmlDoc;
        }

        public void WriteXmlFile(Catalog<XmlFile> catalog)
        {
            // Создаем новый Xml документ.
            var _document = new XmlDocument();

            // Создаем Xml заголовок.
            var xmlDeclaration = _document.CreateXmlDeclaration("1.0", "UTF-8", null);

            // Добавляем заголовок перед корневым элементом.
            _document.AppendChild(xmlDeclaration);

            // Создаем Корневой элемент
            var root = _document.CreateElement("catalog");

            // Получаем все записи телефонной книги.
            foreach (var file in catalog.Files)
            {
                // Создаем элемент записи телефонной книги.
                var fileNode = _document.CreateElement("Files");

                // Создаем зависимые элементы.
                AddChildNode("Name", file.Name, fileNode, _document);
                AddChildNode("Memory", file.Memory.ToString(), fileNode, _document);

                // Добавляем запись телефонной книги в каталог.
                root.AppendChild(fileNode);
            }

            // Добавляем новый корневой элемент в документ.
            _document.AppendChild(root);

            // Сохраняем документ.
            _document.Save(_pathNameXmlDoc);

            Console.WriteLine($"\n\tFiles are successfully written to the XML document { _pathNameXmlDoc} located in the root of the application");
            Console.WriteLine(new string('-',100));

            void AddChildNode(string childName, string childText, XmlElement parentNode, XmlDocument doc)
            {
                var child = doc.CreateElement(childName);
                child.InnerText = childText;
                parentNode.AppendChild(child);
            }
        }
    }
}
