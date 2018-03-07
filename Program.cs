using System;

namespace Generic_Crazy_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test crazy queue;

            CrazyQueue<int> intQ = new CrazyQueue<int>();
            for (int i = 1; i < 11; i++)
                intQ.Enqueue(i);
            Console.WriteLine("The first element is " + intQ.Front + ", and this queue has " + intQ.Size + " elements.");
            foreach (int n in intQ)
                Console.Write(n + ", ");
            Console.WriteLine();
            Console.WriteLine();

            CrazyQueue<string> strQ = new CrazyQueue<string>();
            Console.WriteLine("This queue is empty: " + strQ.IsEmpty);
            Console.WriteLine();

            CrazyQueue<DateTime> dayQ = new CrazyQueue<DateTime>();
            dayQ.Enqueue(new DateTime(1977, 5, 25));
            dayQ.Enqueue(new DateTime(1980, 5, 21));
            dayQ.Enqueue(new DateTime(1983, 5, 25));
            dayQ.Enqueue(new DateTime(1999, 5, 19));
            dayQ.Enqueue(new DateTime(2002, 5, 16));
            dayQ.Enqueue(new DateTime(2005, 5, 19));
            dayQ.Enqueue(new DateTime(2015, 12, 18));
            dayQ.Enqueue(new DateTime(2017, 12, 15));
            dayQ.Enqueue(new DateTime(2019, 12, 20));
            Console.WriteLine("The first element is " + dayQ.Front + ", and this queue has " + dayQ.Size + " elements.");
            foreach (DateTime d in dayQ)
                Console.Write(d.Year + "/" + d.Month + "/" + d.Day + ", ");
            Console.WriteLine();
            Console.WriteLine();

            CrazyQueue<double> normQ = new CrazyQueue<double>(false);
            for (int h = 0; h < 100; h++)
                normQ.Enqueue(h + 1);
            Console.WriteLine("The first element is " + normQ.Front + ", and this queue has " + normQ.Size + " elements.");
            foreach (int r in normQ)
                Console.Write(r + ", ");
            Console.WriteLine();
            Console.WriteLine();

            // I believe that's all the methods and functionality tested.

            Console.ReadLine();
        }
    }
}
