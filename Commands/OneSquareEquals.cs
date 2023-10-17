using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class OneSquareEquals : ICommand
    {
        private readonly IReceiver receiver;
        public OneSquareEquals(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            double square = double.Parse(Console.ReadLine());
            Console.WriteLine(receiver.OneSquareEquals(square));
            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Перевірка, чи є квартира, площа якої дорівнює заданій";
        }
    }
}
