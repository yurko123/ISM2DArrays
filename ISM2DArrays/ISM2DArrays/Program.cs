using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISM2DArrays
{
    class Program
    {
        static void ConsoleConfig(string title)
        {
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(1251); // може буть несумісність кодувань
        }
        static double[,] GetRandomArr(uint height ,uint length, int minVaule, int maxVaule, int precision)
        {
            double[,] arr = new double[height,length];
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arr.GetLength(0); i++)
                for(int j=0;j<arr.GetLength(1);j++)
                arr[i,j] = Math.Round(rnd.NextDouble() * (maxVaule - minVaule) + minVaule, precision);
            return arr;
        }
        static void WriteArray(double[,] arr)
        {
            Console.WriteLine(" Array is :");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write("arr[{0},{1}]= \"{2}\"\t", i,j, arr[i, j]);
                Console.WriteLine();
            }
        }
        static double[,] ProductMatrix(double[,] MatrixA, double[,] MatrixB)
        {
            int Aheigth = MatrixA.GetLength(0), Bheigth = MatrixB.GetLength(0), Alenght = MatrixA.GetLength(1), Blenght = MatrixB.GetLength(0);
            if (Alenght != Bheigth) return null;
            double[,] Arr= new double [Aheigth,Blenght];
            for (int i = 0; i < Aheigth; i++)
                for (int j = 0; j < Blenght; j++)
                    for (int k = 0; k < Alenght; k++)
                        Arr[i,j] += MatrixA[i, k] * MatrixB[k, j];
            return Arr;

                    


        }
        static void Main(string[] args)
        {
            ConsoleConfig("Двовимірні масиви");
            
            Console.WriteLine("Введіть висоту і ширину матриці A");
            uint height=uint.Parse(Console.ReadLine()),lenght=uint.Parse(Console.ReadLine());
            Console.WriteLine("Введіть висоту і ширину матриці B");
            uint height1 = uint.Parse(Console.ReadLine()), lenght1 = uint.Parse(Console.ReadLine());
            double[,] Arr=GetRandomArr(height, lenght, -10, 10, 0);
            double[,] Arr1= GetRandomArr(height1, lenght1, -10, 10, 0);
            WriteArray(Arr);
            WriteArray(Arr1);
            double[,] Arr2 = ProductMatrix(Arr, Arr1);
            if(Arr2==null)Console.WriteLine("Неможливо перемножити матриці!!!");
            else WriteArray(Arr2);

            Console.ReadKey();

        }
    }
}
