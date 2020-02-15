namespace FileMemoryCountManager.XmlDocumentSaver
{
    struct XmlFile
    {
        public string Name { get; private set; }

        public long Memory { get; private set; }

        public XmlFile(string name, long memory)
        {
            Name = name;
            Memory = memory;
        }

        public override string ToString()
        {
            return string.Format(Name, Memory.ToString());
        }

    }
}
