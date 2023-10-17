using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class WriteToXML : ICommand
    {
        private readonly IReceiver receiver;
        public WriteToXML(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            Console.WriteLine("Виберіть спосіб:\n1 - Сереалізація звичайним способом\n2 - Writer-cереалізація");
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out int option);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (option < 1 || option > 2)
                {
                    Console.WriteLine("Число має бути 1 або 2\n");
                    continue;
                }
                receiver.WriteToXML(option);
                break;
            }
        }
        public string GetCommandName()
        {
            return "Записати в XML-файл";
        }
    }
}
