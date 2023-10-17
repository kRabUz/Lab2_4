using Lab2_4.Interfaces;
using System;

namespace Lab2_4.Commands
{
    public class GetAllApartments : ICommand
    {
        private readonly IReceiver receiver;
        public GetAllApartments(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            if (!receiver.IsDocumentInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var vNode in receiver.GetAllApartments())
            {
                Console.WriteLine(vNode);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати перелік всіх дочірніх вузлів файлу Apartments";
        }
    }
}
