using Lab2_4.Enums;
using Lab2_4.Interfaces;
using Lab2_4.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lab2_4
{
    public class Receiver : IReceiver
    {
        private readonly IDataContext context;
        private XDocument ApartmentsDocument;
        public Receiver(IDataContext context)
        {
            this.context = context;
            InitializeXDocument();
        }

        public bool IsDocumentInitialized()
        {
            return ApartmentsDocument != null;
        }

        public void WriteToXML(int option)
        {
            DataInitializer dataInitializer = new DataInitializer(context);
            dataInitializer.InitializeFromConsole();

            SerializeType serializeType = (SerializeType)option;
            switch (serializeType)
            {
                case SerializeType.DefaultXmlSerializer:
                    SerializeCollections(serializeType);
                    break;
                case SerializeType.XmlWriter:
                    SerializeCollections(serializeType);
                    break;
            }
        }
        public void ValidateXMLFiles()
        {
            string[] XMLFiles = Directory.GetFiles($"./XML_FILES");
            if (XMLFiles.Count() == 0)
            {
                return;
            }
            foreach (string XMLFile in XMLFiles)
            {
                XMLValidator.Validate(XMLFile);
            }
        }

        public IEnumerable<XElement> GetAllApartments()
        {
            return ApartmentsDocument.GetRootElements();
        }

        public double GetLargestSquare()
        {
            return ApartmentsDocument.GetRootElements()
                    .Max(apartment => double.Parse(apartment.Element("Square").Value));
        }

        public IEnumerable<XElement> GetSelectedByFirstNumber(string number)
        {
            return ApartmentsDocument.GetRootElements()
                .Where(apartment => apartment.Element("Square").Value.StartsWith(number));
        }

        public int GetCountOfSelectedFloor(string floor)
        {
            return ApartmentsDocument.GetRootElements()
                    .Where(apartment => apartment.Element("Floor").Value == floor)
                    .Count();
        }

        public bool EverySquareBiggerThan(double square)
        {
            return ApartmentsDocument.GetRootElements()
                    .All(apartment => double.Parse(apartment.Element("Square").Value)
                    > square);
        }

        public IEnumerable<XElement> TakeWhileFloor(int floor)
        {
            return ApartmentsDocument.GetRootElements()
                    .TakeWhile(apartment => int.Parse(apartment.Element("Floor").Value)
                    >= floor);
        }

        public int GetSumOfSquare()
        {
            return ApartmentsDocument.GetRootElements()
                    .Sum(apartment => int.Parse(apartment.Element("Square").Value));
        }

        public IEnumerable<IGrouping<int, XElement>> GroupByRooms()
        {
            return ApartmentsDocument.GetRootElements()
                    .OrderBy(apartment => int.Parse(apartment.Element("Rooms").Value))
                    .GroupBy(apartment => int.Parse(apartment.Element("Rooms").Value));
        }

        public IEnumerable<XElement> SortApartments()
        {
            return ApartmentsDocument.GetRootElements()
                    .OrderBy(apartment => double.Parse(apartment.Element("Square").Value));
        }

        public bool OneSquareEquals(double square)
        {
            return ApartmentsDocument.GetRootElements()
                    .Any(apartment => double.Parse(apartment.Element("Square").Value) == square);
        }

        public IEnumerable<XElement> BiggerThanAverage()
        {
            double q1 = ApartmentsDocument.GetRootElements()
                    .Average(apartment => double.Parse(apartment.Element("Square").Value));
            return ApartmentsDocument.GetRootElements()
                    .Where(apartment => double.Parse(apartment.Element("Square").Value) > q1);
        }

        public IEnumerable<XElement> ReverseApartments()
        {
            return ApartmentsDocument.GetRootElements()
                .Reverse();
        }

        public double GetMinSquare()
        {
            return ApartmentsDocument.GetRootElements()
                    .Min(apartment => double.Parse(apartment.Element("Square").Value));
        }

        public IEnumerable<XElement> GetApartmentsWithoutSquareDuplicates()
        {
            return ApartmentsDocument.GetRootElements()
                    .Select(apartment => apartment.Element("Square").Value)
                    .Distinct()
                    .Select(squareValue => ApartmentsDocument.GetRootElements()
                    .First(apartment => apartment.Element("Square").Value == squareValue));
        }

        public IEnumerable<XElement> SkipApartments(int n)
        {
            return ApartmentsDocument.GetRootElements().
                Skip(n);
        }
        private void InitializeXDocument()
        {
            try
            {
                ApartmentsDocument = XMLDataLoader.LoadDocument("Apartments", XMLFilePathCreator.DirectoryName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SerializeCollections(SerializeType serializeType)
        {
            XMLSerializer.SerializeCollection(serializeType, context.Agencies);
            XMLSerializer.SerializeCollection(serializeType, context.Realtors);
            XMLSerializer.SerializeCollection(serializeType, context.Offers);
            XMLSerializer.SerializeCollection(serializeType, context.Apartments);
        }
    }
}
