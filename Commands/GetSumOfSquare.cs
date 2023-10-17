using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetSumOfSquare : ICommand
    {
        private readonly IReceiver receiver;
        public GetSumOfSquare(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            Console.WriteLine($"{receiver.GetSumOfSquare()} м.кв.");

            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Вивести загальну площу всіх квартир";
        }
    }
}
