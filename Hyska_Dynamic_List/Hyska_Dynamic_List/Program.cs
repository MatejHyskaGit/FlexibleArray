using System;

namespace Hyska_Dynamic_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlexArray array = new FlexArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            Console.WriteLine(array.GetAll());

            Console.WriteLine(array.Get(1));

            Console.WriteLine(array.IndexOf(3));

            array.Set(1, 3);
            Console.WriteLine(array.GetAll());

            array.SetMove(1, 2);
            Console.WriteLine(array.GetAll());

            array.ClearValue(2);
            Console.WriteLine(array.GetAll());

            array.ClearIndex(2);
            Console.WriteLine(array.GetAll());

            array.RemoveValue(4);
            Console.WriteLine(array.GetAll());

            array.RemoveIndex(3);
            Console.WriteLine(array.GetAll());
        }
    }
}
