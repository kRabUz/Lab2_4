using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class EverySquareBiggerThan : ICommand
    {
        private readonly IReceiver receiver;
        public EverySquareBiggerThan(IReceiver receiver)
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
            Console.WriteLine(receiver.EverySquareBiggerThan(square));

            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Перевірка, чи всі площі більші за введену";
        }
    }
}
