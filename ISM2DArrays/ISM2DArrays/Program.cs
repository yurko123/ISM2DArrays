using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ISM2DArrays
{
    class Program
    {   static double det_res=0;
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
        static double Det (double[,] Matrix)
        {
           
            int n = Matrix.GetLength(0);
            double sum = 0;
            if (n == 1) return Matrix[0, 0];
            if (n == 2) return Matrix[0, 0] * Matrix[1, 1] - Matrix[1, 0] * Matrix[0, 1];
            for (int i = 0; i < n; i++)
                sum += Det(Minor(Matrix, 0, i)) * Matrix[0, i] * Math.Pow(-1, i);
            return det_res+sum; 
            
        }
        static double[,] Minor(double[,] minor, int i, int j)
        {
            int n = minor.GetLength(0);
            double[,]new_minor=new double [n-1,n-1];
            for(int k=0,z=0;k<n;k++)
            {  if(k==i) continue;
                for (int d = 0,x=0; d < n; d++)
                {
                    if (d == j) continue;
                    new_minor[z,x] = minor[k,d];
                    x++;

                }
                z++;
            }

            return new_minor;

        }
        static double[,] rotateMatrix(double[,] Matrix)
        {
            if (Matrix.GetLength(0) != Matrix.GetLength(1) && Math.Abs(Det(Matrix)) < 1e-5) return null;
            int n=Matrix.GetLength(0);
            double [,] res_Matrix=new double [n,n];
            for(int i=0;i<n;i++)
                for(int j=0;j<n;j++)
                    res_Matrix[j,i]=Math.Pow(-1, i+j)* Det(Minor(Matrix,i,j));
            return res_Matrix;
        }
        static void Main(string[] args)
        {
            ConsoleConfig("Двовимірні масиви ");
            Stopwatch _time = new Stopwatch();
            /*Console.WriteLine("Введіть висоту і ширину матриці A");
            uint height=uint.Parse(Console.ReadLine()),lenght=uint.Parse(Console.ReadLine());
           Console.WriteLine("Введіть висоту і ширину матриці B");
            uint height1 = uint.Parse(Console.ReadLine()), lenght1 = uint.Parse(Console.ReadLine());
          double[,] Arr=GetRandomArr(height, lenght, -10, 10, 0);
           double[,] Arr1= GetRandomArr(height1, lenght1, -10, 10, 0);
            WriteArray(Arr);
            WriteArray(Arr1);
            double[,] Arr2 = ProductMatrix(Arr, Arr1);
            if (Arr2 == null) Console.WriteLine("Неможливо перемножити матриці!!!");
            else WriteArray(Arr2);*/
             Console.WriteLine("Введіть висоту або ширину матриці C ");
            uint height2 = uint.Parse(Console.ReadLine());
            double[,] Arr3 = GetRandomArr(height2, height2, -10, 10, 0);
            WriteArray(Arr3);
            //Arr3=rotateMatrix(Arr3);
            _time.Start();
            Console.WriteLine("Детермінант дорівнює {0}",Det(Arr3));
            _time.Restart();
            Console.WriteLine("пораховано за "+ _time.Elapsed);
            //if (Arr3 == null) Console.WriteLine("Детермінант дорівнює нулю!");
            //else { Console.WriteLine("Обернена матриця :"); WriteArray(Arr3); }
            

          Console.ReadKey();

        }
    }
}
