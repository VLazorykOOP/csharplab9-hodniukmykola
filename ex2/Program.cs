using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"F:\numbers.txt"; // Шлях до файлу на диску F:

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено за шляхом: " + filePath);
            return;
        }

        Queue<int> positiveQueue = new Queue<int>();
        Queue<int> negativeQueue = new Queue<int>();

        // Один прохід по файлу
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (int.TryParse(line, out int number))
                {
                    if (number >= 0)
                        positiveQueue.Enqueue(number);
                    else
                        negativeQueue.Enqueue(number);
                }
            }
        }

        Console.WriteLine("Позитивні числа:");
        while (positiveQueue.Count > 0)
        {
            Console.WriteLine(positiveQueue.Dequeue());
        }

        Console.WriteLine("Негативні числа:");
        while (negativeQueue.Count > 0)
        {
            Console.WriteLine(negativeQueue.Dequeue());
        }
    }
}
