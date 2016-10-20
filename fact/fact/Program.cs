using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fact
{
    class Program
    {
        static double fact1(double n)
        {
            if (n <= 1) return 1;
            return n * fact1(n-1);
        }
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Console.WriteLine(fact1(n));
            Console.ReadKey();

        }
    }
}
