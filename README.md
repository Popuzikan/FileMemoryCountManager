# FileMemoryCounter Project

The project is the test console application with the open code. The application allows to run for search of all files and folders in the storage selected by the user, to count the sum of values of bytes of memory of the found files, rezults works is displayed in a user-friendly view, and is saved in Xml document in the root directory of the program. 

## Getting Started

To start the project it is necessary to open the FileMemoryCountManager.sln file and to compile it in the development environment.

### Prerequisites

For correct operation of application you need to install Microsoft Visual Studio with the version of the 
.NET Framework not lower than 4.7.0

## Contributing

The project was implemented on the basis of a design pattern the Facade. 
In detail about project classes:
- class Client: provides interaction of the user with managers the choice of folders.
- the class ServiceProvider provides the interface for search of files and folders in the directory specified glued which are stored in a type of couples a key value.
- the class FileManager provides the interface for calculation of the sum of values of memory of each byte for the files found by means of ServiceProvider and also makes record of the found information in the XML file in a user-friendly view.
- the class XmlProvider provides interfaces, for a added of data in Catalog storage, and record their XML specified by the user the document.
- AppCreator - directly a facade which provides the interface to the client for work with components. (generics all components, necessary for operation of application)

## Authors

* **Alex Puzanov** 