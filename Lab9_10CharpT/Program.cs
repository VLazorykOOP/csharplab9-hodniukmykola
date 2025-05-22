using System;

class Stack
{
    private char[] items;
    private int top;

    public Stack(int size)
    {
        items = new char[size];
        top = -1;
    }

    public void Push(char item)
    {
        if (top < items.Length - 1)
        {
            items[++top] = item;
        }
    }

    public char Pop()
    {
        if (!IsEmpty())
        {
            return items[top--];
        }
        return '\0'; // Порожній символ як ознака помилки
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}

class Program
{
    static bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        Stack stack = new Stack(s1.Length);

        // Додаємо всі символи s1 у стек
        foreach (char c in s1)
        {
            stack.Push(c);
        }

        // Порівнюємо символи з s2, знімаючи зі стеку
        foreach (char c in s2)
        {
            if (stack.Pop() != c)
                return false;
        }

        return true;
    }

    static void Main()
    {
        string s1 = "hello";
        string s2 = "lleh";

        Console.WriteLine($"s2 є зворотним до s1? {IsReverse(s1, s2)}"); // Очікується: True
    }
}
