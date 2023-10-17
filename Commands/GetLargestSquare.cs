using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetLargestSquare : ICommand
    {
        private readonly IReceiver receiver;
        public GetLargestSquare(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            Console.WriteLine($"{receiver.GetLargestSquare()} м.кв.");
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати найбільшу площу квартири";
        }
    }
}
