using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetApartmentsWithoutSquareDuplicates : ICommand
    {
        private readonly IReceiver receiver;
        public GetApartmentsWithoutSquareDuplicates(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var apartment in receiver.GetApartmentsWithoutSquareDuplicates())
            {
                string address = (string)apartment.Element("Address");
                int floor = (int)apartment.Element("Floor");
                double square = (double)apartment.Element("Square");
                Console.WriteLine($"Адреса - {address}, {floor} поверх, площа - {square} м.кв.");
            }
            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Вивести список квартир без тих, площа яких повторюється";
        }
    }
}
