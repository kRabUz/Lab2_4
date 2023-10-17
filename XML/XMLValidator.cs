using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Lab2_4.XML
{
    public class XMLValidator
    {
        private static XmlReaderSettings settings = new XmlReaderSettings();
        static XMLValidator()
        {
            settings.ValidationType = ValidationType.Schema;
            string[] schemas = Directory.GetFiles($"{Directory.GetCurrentDirectory()}/XMLSchemas");
            foreach (var schemaPath in schemas)
            {
                settings.Schemas.Add("", schemaPath);
            }
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
        }
        public static void Validate(string path)
        {
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (Exception)
                {
                    throw;
                }
            };
        }
        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            throw new Exception($"Файл не відповідає схемі валідації: {args.Message}");
        }
    }
}
