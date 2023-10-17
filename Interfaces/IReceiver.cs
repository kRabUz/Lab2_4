using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab2_4.Interfaces
{
    public interface IReceiver
    {
        void WriteToXML(int option);
        void ValidateXMLFiles();
        bool IsDocumentInitialized();
        IEnumerable<XElement> GetAllApartments();
        double GetLargestSquare();
        IEnumerable<XElement> GetSelectedByFirstNumber(string number);
        int GetCountOfSelectedFloor(string floor);
        bool EverySquareBiggerThan(double square);
        IEnumerable<XElement> TakeWhileFloor(int floor);
        int GetSumOfSquare();
        IEnumerable<IGrouping<int, XElement>> GroupByRooms();
        IEnumerable<XElement> SortApartments();
        bool OneSquareEquals(double square);
        IEnumerable<XElement> BiggerThanAverage();
        IEnumerable<XElement> ReverseApartments();
        double GetMinSquare();
        IEnumerable<XElement> GetApartmentsWithoutSquareDuplicates();
        IEnumerable<XElement> SkipApartments(int n);
    }
}
