using Lab2_4.Commands;
using Lab2_4.Interfaces;
using System;

namespace Lab2_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IDataContext context = new DataContext();
            IReceiver receiver = new Receiver(context);
            CommandInvoker invoker = new CommandInvoker();
            invoker.SetUpCommand(new WriteToXML(receiver));
            invoker.SetUpCommand(new ValidateXMLFiles(receiver));
            invoker.SetUpCommand(new GetAllApartments(receiver));
            invoker.SetUpCommand(new GetLargestSquare(receiver));
            invoker.SetUpCommand(new GetSelectedByFirstNumber(receiver));
            invoker.SetUpCommand(new GetCountOfSelectedFloor(receiver));
            invoker.SetUpCommand(new EverySquareBiggerThan(receiver));
            invoker.SetUpCommand(new TakeWhileFloor(receiver));
            invoker.SetUpCommand(new GetSumOfSquare(receiver));
            invoker.SetUpCommand(new GroupByRooms(receiver));
            invoker.SetUpCommand(new SortApartments(receiver));
            invoker.SetUpCommand(new OneSquareEquals(receiver));
            invoker.SetUpCommand(new BiggerThanAverage(receiver));
            invoker.SetUpCommand(new ReverseApartments(receiver));
            invoker.SetUpCommand(new GetMinSquare(receiver));
            invoker.SetUpCommand(new GetApartmentsWithoutSquareDuplicates(receiver));
            invoker.SetUpCommand(new SkipApartments(receiver));
            Menu.GenerateMenu(invoker.GetCommands());
            Menu.PrintMenu();
            int commandCount = invoker.GetCommandsCount();
            Console.WriteLine("Для закриття консолі введіть 0\n");
            while (true)
            {
                Console.Write("Запит #");
                bool flag = int.TryParse(Console.ReadLine(), out int option);
                if (!flag)
                {
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                if (option == 0)
                {
                    return;
                }
                if (option < 1 || option > commandCount)
                {
                    Console.WriteLine($"Введіть число в межах від 1 до {commandCount}\n");
                    continue;
                }
                Console.WriteLine(invoker.GetCommandName(option - 1) + ":\n");
                try
                {
                    invoker.ExecuteCommand(option - 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
