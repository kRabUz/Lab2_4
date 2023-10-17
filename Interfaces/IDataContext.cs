using Lab2_4.Classes;
using System.Collections.Generic;

namespace Lab2_4.Interfaces
{
    public interface IDataContext
    {
        IEnumerable<Agency> Agencies { get; set; }
        IEnumerable<Realtor> Realtors { get; set; }
        IEnumerable<Apartment> Apartments { get; set; }
        IEnumerable<Offer> Offers { get; set; }
    }
}
