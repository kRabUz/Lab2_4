using Lab2_4.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab2_4.XML
{
    public class XMLDataLoader
    {
        private static string path;
        public static List<T> LoadData<T>(SerializeType serializeType) where T : new()
        {
            path = XMLFilePathCreator.GetPath<T>(serializeType);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файлу за шляхом {path} не знайдено");
            }
            switch (serializeType)
            {
                case SerializeType.DefaultXmlSerializer:
                    return DefaultDeserialize<T>(path);
                case SerializeType.XmlWriter:
                    return XMLDocumentDeserialize<T>(path);
                default:
                    return null;
            }
        }
        private static List<T> DefaultDeserialize<T>(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (List<T>)xmlSerializer.Deserialize(fs);
            }
        }
        private static List<T> XMLDocumentDeserialize<T>(string path) where T : new()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement root = xmlDocument.DocumentElement;
            List<T> instanceList = new List<T>();

            foreach (XmlNode instanceNode in root)
            {
                T instance = FillInstanceProps<T>(instanceNode);
                instanceList.Add(instance);
            }
            return instanceList;
        }
        private static T FillInstanceProps<T>(XmlNode instanceNode) where T : new()
        {
            Type instanceType = typeof(T);
            PropertyInfo property;
            T instance = new T();

            foreach (XmlNode xmlPropTag in instanceNode)
            {
                property = instanceType.GetProperty(xmlPropTag.Name);
                object value = ConvertHelper.ChangeType(property?.PropertyType, xmlPropTag.InnerText);
                property?.SetValue(instance, value);
            }
            return instance;
        }
        public static XDocument LoadDocument(string fileName, string directory)
        {
            path = XMLFilePathCreator.GetPath(directory, fileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файлу {fileName} не знайдено, створіть або завантажте файл з такою назвою");
            }
            return XDocument.Load(path);
        }
    }
}
