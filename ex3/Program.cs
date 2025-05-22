using System;
using System.Collections;

class Stack : IEnumerable, ICloneable
{
    private ArrayList items = new ArrayList();

    public void Push(object item)
    {
        items.Add(item);
    }

    public object Pop()
    {
        if (items.Count == 0)
            return null;

        object item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }

    public object Clone()
    {
        Stack clone = new Stack();
        foreach (var item in items)
            clone.Push(item);
        return clone;
    }
}

class Program
{
    static bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        Stack stack = new Stack();
        foreach (char c in s1)
            stack.Push(c);

        foreach (char c in s2)
        {
            if ((char)stack.Pop() != c)
                return false;
        }

        return true;
    }

    static void Main()
    {
        string s1 = "abcd";
        string s2 = "dcba";

        Console.WriteLine($"s2 є зворотним до s1? {IsReverse(s1, s2)}"); // Очікується: True
    }
}
