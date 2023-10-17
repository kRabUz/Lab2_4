using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GroupByRooms : ICommand
    {
        private readonly IReceiver receiver;
        public GroupByRooms(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var group in receiver.GroupByRooms())
            {
                int rooms = group.Key;
                Console.WriteLine($"Квартири з {rooms} кімнатами:");

                foreach (var apartment in group)
                {
                    string address = (string)apartment.Element("Address");
                    int floor = (int)apartment.Element("Floor");
                    double square = (double)apartment.Element("Square");
                    Console.WriteLine($"Адреса - {address}, {floor} поверх, площа - {square} м.кв.");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Виведення квартир, згрупованих за кількістю кімнат";
        }
    }
}
