using System;
using System.Collections;
using System.IO;

class NumberComparer : IComparer
{
    public int Compare(object x, object y)
    {
        // Не змінює порядок, просто дає змогу використовувати IComparer
        return 0;
    }
}

class Program
{
    static void Main()
    {
        string filePath = @"F:\numbers.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        ArrayList positives = new ArrayList();
        ArrayList negatives = new ArrayList();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (int.TryParse(line, out int number))
                {
                    if (number >= 0)
                        positives.Add(number);
                    else
                        negatives.Add(number);
                }
            }
        }

        Console.WriteLine("Позитивні числа:");
        foreach (int n in positives)
            Console.WriteLine(n);

        Console.WriteLine("Негативні числа:");
        foreach (int n in negatives)
            Console.WriteLine(n);
    }
}
