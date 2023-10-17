using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetMinSquare : ICommand
    {
        private readonly IReceiver receiver;
        public GetMinSquare(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            Console.WriteLine($"{receiver.GetMinSquare()} м.кв.");
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати найменшу площу квартири";
        }
    }
}
