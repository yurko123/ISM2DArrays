using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace ISMMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix.ConsoleConfig("Матриці");
            Console.WriteLine("Введіть кількість рядків і стовпчиків ");
            try
            {
                uint rows = uint.Parse(Console.ReadLine());
                uint cols = uint.Parse(Console.ReadLine());
                int[,] arr = Matrix.GetRandomArr(rows, cols, -2, 10);

                Matrix.WriteArray(arr);
                Console.WriteLine("кількість рядків, які не містять жодного нульового елемента :" + Matrix.NumRowsZero(arr));
                Console.WriteLine("максимальне із чисел, що зустрічається в заданій матриці більше одного разу :" + Matrix.DoubleMax(arr));
                Console.WriteLine("кількість стовпців, які містять хоча б один нульовий елемент :" + Matrix.NumRowsWithZero(arr));
                Console.WriteLine("номер рядка, в якому знаходиться найдовша серія однакових елементів :" + Matrix.Seriya(arr));
                Console.WriteLine("добуток елементів в тих рядках, які не містять від’ємних елементів :");
                Matrix.ProductRows(arr);
                try
                { Console.WriteLine("максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці :" + Matrix.SumDiagonals(arr)); }
                catch(Exception)
                {
                    Console.WriteLine("Ви ввели неквадратну матрицю :");
                }
                Console.WriteLine("суму елементів в тих стовпцях, які не містять від’ємних елементів :");
                Matrix.SumCols(arr);

                try
                { Console.WriteLine("мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці :" + Matrix.SumDiagonals2(arr)); }
                catch (Exception)
                {
                    Console.WriteLine("Ви ввели неквадратну матрицю :");
                }
                Console.WriteLine("суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент :");
                Matrix.SumColsWithZero(arr);
                Console.WriteLine("обернену матрицю :");
                try { Matrix.WriteArray(Matrix.rotateMatrix(arr)); }
                catch (Exception)
                { Console.WriteLine("Матриця не квадратна або не існує обернена матриця"); }
                Console.WriteLine("транспоновану матрицю :");
                Matrix.WriteArray(Matrix.Transponder(arr));
            }
            catch (FormatException )
            {
                Console.WriteLine("Помилка !!!! Ви вели не ціле число!!!");
            }
            catch (OverflowException )
            {
                Console.WriteLine("Помилка !!! Ваше число виходить за межі типу данних!!!");
            }
      
            Console.ReadKey();

        }
    }
}
