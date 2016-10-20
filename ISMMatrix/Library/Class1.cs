using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Matrix
    {
        public static void ConsoleConfig(string title)
        {
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(1251); // може буть несумісність кодувань
        }

        public static int[,] GetRandomArr(uint height, uint length, int minVaule, int maxVaule)
        {
            int[,] arr = new int[height, length];
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(minVaule, maxVaule);
            return arr;
        }

        public static void WriteArray(int[,] arr)
        {
            Console.WriteLine(" Array is :");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write("arr[{0},{1}]= \"{2}\"\t", i, j, arr[i, j]);
                Console.WriteLine();
            }
        }

        public static int NumRowsZero(int[,] arr)
        {
            bool RES;
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int l = 0;
            for (int i = 0; i < rows; i++)
            {
                RES = true;
                for (int j = 0; j < cols; j++)
                    if (arr[i, j] == 0) { RES = false; break; }
                if (RES) l++;
            }
            return l;
        }

        public static int DoubleMax(int[,] arr)
        {
            int max=arr[0,0];
            int MAX=arr[0,0];
             for(int i=0;i< arr.GetLength(0);i++)
                for(int j=0;j<arr.GetLength(1);j++)
                {
                  
                    if (MAX < arr[i, j])
                    max = arr[i, j];
                 
                }
             return MAX;
        }

        public static int NumRowsWithZero(int[,] arr)
        {
            bool RES;
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int l = 0;
            for (int i = 0; i < cols; i++)
            {
                RES = false;
                for (int j = 0; j < rows; j++)
                    if (arr[j, i] == 0) { RES = true; break; }
                if (RES) l++;
            }
            return l;
        }

        public static int Seriya(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int k = 0, l = 0;
            int[] res = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    if (arr[i, j] == arr[i, j+1]) l++;
                    else if (k < l) k = l;
                }
                res[i] = k;
                k = 0; l = 0;
            }
            int max = res[0];
            int el = 0;
            for (int i = 1; i < rows; i++)
                if (res[i] > max) { max = res[i]; el = i; }
            return el;
        }

        public static void ProductRows(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int j = 0, product = 1;
            for (int i = 0; i < rows; i++)
            {
                for (j = 0; j < cols; j++)
                    if (arr[i, j] < 0) break;
                if (j == cols)
                {
                    product = 1; for (int k = cols - 1; k >= 0; k--) product *= arr[i, k];
                    Console.WriteLine("Добуток {0} рядка : {1}", i, product);
                }
            }
        }

       public static int SumDiagonals(int[,] arr)
        {
            int d = arr.GetLength(0);
            if (d!=arr.GetLength(1)) throw new Exception ("Існує тільки з квадратної матриці ");
           int[] sum =new int [d*2];
           for (int k = 0; k <d; k++)
           for (int i = 0, j = k; i < d && j < d; i++, j++)
               {
                   sum[k] += arr[i, j];
                   sum[d * 2 - k-1] += arr[j, i];
               }
           int max = sum[0];
           for (int i = 1; i < sum.Length; i++)
               if (max < sum[i]) max = sum[i];
            return max;
        }

       public static void SumCols(int[,] arr)
       {
           int rows = arr.GetLength(0);
           int cols = arr.GetLength(1);
           int j = 0, sum= 0;
           for (int i = 0; i < cols; i++)
           {
               for (j = 0; j < rows; j++)
                   if (arr[j,i] < 0) break;
               if (j == rows)
               {
                   sum = 0; for (int k = rows - 1; k >= 0; k--) sum+= arr[k, i];
                   Console.WriteLine("Сумма {0} стовпця : {1}", i, sum);
               }
           }
       }

       public static int SumDiagonals2 (int[,] arr)
       {
           int d = arr.GetLength(0);
           if (d != arr.GetLength(1)) throw new Exception("Існує тільки з квадратної матриці ");
           int[] sum = new int[d * 2];
           for (int k = d-1; k >=0; k--)
               for (int i = 0, j = k; i < d && j>=0; i++, j--)
               {
                   sum[k] += Math.Abs(arr[i, j]);
                   sum[d+k] += Math.Abs(arr[d-i-1, d-j-1]);
               }
           int min= sum[0];
           for (int i = 1; i < sum.Length; i++)
               if (min > sum[i]) min = sum[i];
           return min;
       }

       public static void  SumColsWithZero(int[,] arr)
       {
           bool RES;
           int Sum=0;
           int rows = arr.GetLength(0);
           int cols = arr.GetLength(1);
           int l = 0;
           for (int i = 0; i < cols; i++)
           {  
               RES = false;
               for (int j = 0; j < rows; j++)
                   if (arr[j,i] < 0) { RES = true; break; }
               if (RES)
               {
                   Sum = 0;
                   for (int z = 0; z < rows; z++)
                       Sum += arr[z, i];
                   Console.WriteLine("Сумма {0} стовпця :{1}", i, Sum);
               }
           }
          
       }

       public static int Det(int[,] Matrix)
       {

           int n = Matrix.GetLength(0);
           int sum = 0;
           if (n == 1) return Matrix[0, 0];
           if (n == 2) return Matrix[0, 0] * Matrix[1, 1] - Matrix[1, 0] * Matrix[0, 1];
           for (int i = 0; i < n; i++)
               sum += Det(Minor(Matrix, 0, i)) * Matrix[0, i] * (int)Math.Pow(-1, i);
           return sum;

       }
       public static int[,] Minor(int[,] minor, int i, int j)
       {
           int n = minor.GetLength(0);
           int[,] new_minor = new int[n - 1, n - 1];
           for (int k = 0, z = 0; k < n; k++)
           {
               if (k == i) continue;
               for (int d = 0, x = 0; d < n; d++)
               {
                   if (d == j) continue;
                   new_minor[z, x] = minor[k, d];
                   x++;

               }
               z++;
           }

           return new_minor;

       }
       public static int[,] rotateMatrix(int[,] Matrix)
       {
           if (Matrix.GetLength(0) != Matrix.GetLength(1) ||Det(Matrix)==0) throw new Exception("error!");
           int n = Matrix.GetLength(0);
           int[,] res_Matrix = new int[n, n];
           for (int i = 0; i < n; i++)
               for (int j = 0; j < n; j++)
                   res_Matrix[j, i] = (int)Math.Pow(-1, i + j) * Det(Minor(Matrix, i, j));
           return res_Matrix;
       }

       public static int[,] Transponder(int[,] arr)
       {
           int rows = arr.GetLength(0), cols = arr.GetLength(1);
           int[,] newArr = new int[cols, rows];
           for (int i = 0; i < rows; i++)
               for (int j = 0; j < cols; j++)
                   newArr[j, i] = arr[i, j];
           return newArr;
       }
    }
}
