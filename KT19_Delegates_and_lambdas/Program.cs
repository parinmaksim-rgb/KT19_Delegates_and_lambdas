namespace KT19
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const string MenuProcess = "1";
        private const string MenuExit = "2";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Ввести список чисел и запустить обработку");
                Console.WriteLine("2 - Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case MenuProcess:
                        ProcessNumbers();
                        break;
                    case MenuExit:
                        return;
                    default:
                        Console.WriteLine("Неверный ввод, повторите попытку.\n");
                        break;
                }
            }
        }

        static void ProcessNumbers()
        {
            NumberData data = new NumberData();
            NumberProcessor processor = new NumberProcessor(data.SavedResults);

            Console.WriteLine("Введите числа через пробел (например: 1 2 3 4 5 6):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int parsed))
                {
                    data.Numbers.Add(parsed);
                }
            }

            List<int> evens = new List<int>();
            List<int> squares = new List<int>();

            Console.WriteLine("\nЗапуск конвейера (объединённое действие: вывод на экран):");
            foreach (int num in data.Numbers)
            {
                if (processor.IsEven(num))
                {
                    evens.Add(num);
                    int squared = processor.Square(num);
                    squares.Add(squared);

                    processor.CombinedAction(squared);
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Действие: отфильтрованные чётные");
            Console.WriteLine($"Ожидаемый результат: {string.Join(", ", evens)}\n");

            Console.WriteLine("Действие: квадраты после преобразования");
            Console.WriteLine($"Ожидаемый результат: {string.Join(", ", squares)}\n");

            Console.WriteLine("Действие: объединённое действие");
            Console.WriteLine($"Ожидаемый результат: значения выведены на экран И сохранены в списке ({data.SavedResults.Count} элемента)\n");

            Console.WriteLine(new string('-', 50) + "\n");
        }
    }
}