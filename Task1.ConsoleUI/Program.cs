﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Task1;

namespace Task1.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            Catalog catalog;
            using (var fileStream = File.OpenRead("books.xml"))
            {
                catalog = (Catalog)serializer.Deserialize(fileStream);
            }

            catalog.Books[0].PublishDate = catalog.Books[0].PublishDate.AddYears(30);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, Catalog.XmlNamespace);
            using (var xmlWriter = XmlWriter.Create("books1.xml", new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            }))
            {
                serializer.Serialize(xmlWriter, catalog, namespaces);
            }
        }
    }
}
