using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetCountOfSelectedFloor : ICommand
    {
        private readonly IReceiver receiver;
        public GetCountOfSelectedFloor(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            string floor = Console.ReadLine();
            Console.WriteLine($"{receiver.GetCountOfSelectedFloor(floor)} квартир, що знаходяться на {floor} поверсі");

            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Вивести кількість квартир, що знаходиться на n поверсі";
        }
    }
}
