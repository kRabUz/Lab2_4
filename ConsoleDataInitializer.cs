using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lab2_4
{
    static class ConsoleDataInitializer
    {
        static public List<T> CreateCollection<T>() where T : new()
        {
            Console.Write($"Введіть кількість об'єктів типу {typeof(T).Name}: ");
            int instanceCount;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out instanceCount);
                if (!flag)
                {
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                break;
            }
            List<T> list = new List<T>();
            for (int i = 0; i < instanceCount; i++)
            {
                Console.WriteLine($"{typeof(T).Name} {i + 1}:");
                list.Add(CreateInstance<T>());
            }
            return list;
        }

        static private T CreateInstance<T>() where T : new()
        {
            PropertyInfo[] publicProps = typeof(T).GetProperties();
            T instance = new T();
            foreach (var prop in publicProps)
            {
                object value = null;
                while (value == null)
                {
                    Console.Write($"{prop.Name}:");
                    try
                    {
                        value = ConvertHelper.ChangeType(prop.PropertyType, Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Неможливо конвертувати, введіть значення типу {prop.PropertyType.Name}");
                    }
                }
                prop.SetValue(instance, value);
            }
            return instance;
        }
    }
}
