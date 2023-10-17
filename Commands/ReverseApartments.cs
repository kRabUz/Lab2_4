using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class ReverseApartments : ICommand
    {
        private readonly IReceiver receiver;
        public ReverseApartments(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var apartment in receiver.ReverseApartments())
            {
                string address = (string)apartment.Element("Address");
                int floor = (int)apartment.Element("Floor");
                double square = (double)apartment.Element("Square");
                Console.WriteLine($"Адреса - {address}, {floor} поверх, площа - {square} м.кв.");
            }
        }
        public string GetCommandName()
        {
            return "Вивести список квартир в зворотньому порядку";
        }
    }
}
