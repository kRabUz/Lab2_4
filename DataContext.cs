using Lab2_4.Classes;
using Lab2_4.Interfaces;
using System.Collections.Generic;

namespace Lab2_4
{
    public class DataContext : IDataContext
    {
        public IEnumerable<Agency> Agencies { get; set; }
        public IEnumerable<Realtor> Realtors { get; set; }
        public IEnumerable<Apartment> Apartments { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
