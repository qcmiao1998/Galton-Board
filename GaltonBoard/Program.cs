using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaltonBoard
{
    class Program
    {
        static int _floor;
        static uint _total = new uint();
        static void Main(string[] args)
        {
            Console.Out.Write("Floor: ");
            _floor = Int32.Parse(Console.In.ReadLine());
            Console.Out.Write("Num: ");
            uint num = UInt32.Parse(Console.In.ReadLine());
            uint[] count = new UInt32[_floor];
            Random random = new Random(Environment.TickCount);
            while (true)
            {
                uint numb = num;
                DateTime starTime = DateTime.Now;
                while (num > 0)
                {
                    num--;
                    _total++;
                    float position = (float)(_floor + 1) / 2;
                    for (int i = 0; i < _floor - 1; i++)
                    {
                        position += random.Next() % 2 == 0 ? 0.5f : -0.5f;
                    }
                    count[(int) position - 1]++;
                } 
                DateTime endTime = DateTime.Now;
                Draw(count);
                Console.Out.WriteLine($"Speed: {(numb / (endTime - starTime).TotalSeconds):#0.000} s-1");
                Console.Out.Write("\nAdd: ");
                num = uint.Parse(Console.In.ReadLine());
            }

        }

        private static void Draw(uint[] countInts)
        {
            Console.Clear();
            Console.WriteLine($"Total Floor: {_floor}\n");
            for (int i = 0; i < _floor; i++)
            {
                string outStr = String.Empty;
                outStr += i + 1;
                outStr += "\t|";
                for (uint j = 0; j < Math.Round(countInts[i] / (countInts.Max() * 1.2) * 100); j++)
                {
                    outStr += "*";
                }

                for (uint j = 0; j < 100 - Math.Round(countInts[i] / (countInts.Max() * 1.2) * 100); j++)
                {
                    outStr += " ";
                }

                outStr += $"| {countInts[i]}";
                Console.Out.WriteLine(outStr);
            }
            Console.Out.WriteLine($"\nTotal Bean: {_total}");
        }
    }
}
