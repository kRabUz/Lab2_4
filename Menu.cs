using Lab2_4.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab2_4
{
    public static class Menu
    {
        private static readonly List<string> _commands = new List<string>();
        public static void GenerateMenu(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                _commands.Add(command.GetCommandName());
            }
        }
        public static void PrintMenu()
        {
            for (int index = 0; index < _commands.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {_commands[index]}");
            }
            Console.WriteLine();
        }
    }
}
