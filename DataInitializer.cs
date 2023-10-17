using Lab2_4.Classes;
using Lab2_4.Interfaces;

namespace Lab2_4
{
    public class DataInitializer
    {
        private readonly IDataContext context;

        public DataInitializer(IDataContext context)
        {
            this.context = context;
        }
        public void InitializeFromConsole()
        {
            context.Agencies = ConsoleDataInitializer.CreateCollection<Agency>();
            context.Realtors = ConsoleDataInitializer.CreateCollection<Realtor>();
            context.Offers = ConsoleDataInitializer.CreateCollection<Offer>();
            context.Apartments = ConsoleDataInitializer.CreateCollection<Apartment>();
        }
    }
}
