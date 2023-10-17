using Lab2_4.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Lab2_4.XML
{
    public class XMLSerializer
    {
        private static string path;
        private static Type instanceType;
        public static void SerializeCollection<T>(SerializeType serializeType, IEnumerable<T> collection)
        {
            instanceType = typeof(T);
            path = XMLFilePathCreator.GetPath<T>(serializeType);

            switch (serializeType)
            {
                case SerializeType.DefaultXmlSerializer:
                    DefaultSerializer(collection, path);
                    break;
                case SerializeType.XmlWriter:
                    WriterSerializer(collection, path);
                    break;
            }
        }
        private static void DefaultSerializer<T>(IEnumerable<T> collection, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(typeof(T).Name + "s"));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, collection.ToList());
            }
        }
        private static void WriterSerializer<T>(IEnumerable<T> collection, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            PropertyInfo[] instanceProps = instanceType.GetProperties();

            using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
            {
                xmlWriter.WriteStartElement($"{instanceType.Name}s");
                foreach (var item in collection)
                {
                    xmlWriter.WriteStartElement($"{instanceType.Name}");
                    foreach (var prop in instanceProps)
                    {
                        object propValue = prop.GetValue(item);
                        string valueToWrite = propValue.ToString();
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            DateTime dateTime = Convert.ToDateTime(propValue);
                            valueToWrite = dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                        }
                        xmlWriter.WriteElementString(prop.Name, valueToWrite);
                    }
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
