using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab2_4.XML
{
    static class XMLExtensions
    {
        public static IEnumerable<XElement> GetRootElements(this XDocument xDocument)
        {
            return xDocument?.Root?.Elements();
        }
    }
}
