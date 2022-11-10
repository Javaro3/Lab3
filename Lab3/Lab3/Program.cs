using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int line, column;
            Matrix A = new Matrix();
            Matrix B = new Matrix();
            Matrix C = new Matrix();

            Console.Write("Укажите количество линий в матрице A: ");
            line = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите количество столбцов в матрице A: ");
            column = Convert.ToInt32(Console.ReadLine());
            A.CreateMatrix(line, column);
            A.GetSumSquaredForOperator();
            Console.Write("Укажите количество линий в матрице B: ");
            line = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите количество столбцов в матрице B: ");
            column = Convert.ToInt32(Console.ReadLine());
            B.CreateMatrix(line, column);
            Console.Write("Укажите количество линий в матрице C: ");
            line = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите количество столбцов в матрице C: ");
            column = Convert.ToInt32(Console.ReadLine());
            C.CreateMatrix(line, column);
            while (isWork)
            {
                Console.WriteLine("1. Вывод матриц");
                Console.WriteLine("2. Сумма квадратов отрицательных элементов каждой матрицы");
                Console.WriteLine("3. Вычислить A-B и B-A-C");
                Console.WriteLine("4. Если A<=B<=C заменить все отрицательные элементы матрицы A и B на значение суммы квадратов положительных\n элементов расположенных ниже минимального среди элементов строк с номерами кратными 3 в матрице С.");
                Console.WriteLine("5. Выход");
                int choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Матрица A: ");
                        A.ShowMatrix();
                        Console.WriteLine("Матрица B: ");
                        B.ShowMatrix();
                        Console.WriteLine("Матрица C: ");
                        C.ShowMatrix();
                        break;
                    case 2:
                        Console.WriteLine($"Сумма квадратов отрицательных элементов матрицы A: {A.GetSumSquerad()}");
                        Console.WriteLine($"Сумма квадратов отрицательных элементов матрицы B: {B.GetSumSquerad()}");
                        Console.WriteLine($"Сумма квадратов отрицательных элементов матрицы C: {C.GetSumSquerad()}");
                        break;
                    case 3:
                        Matrix resault = new Matrix();
                        resault = A - B;
                        Console.WriteLine("Результат разности матриц A-B: ");
                        resault.ShowMatrix();
                        resault = B - A - C;
                        Console.WriteLine("Результат разности матриц B-A-C: ");
                        resault.ShowMatrix();
                        break;
                    case 4:
                        if ((A <= B) && (B <= C))
                        {
                            A.ChangeElements(C);
                            B.ChangeElements(C);
                            Console.WriteLine("Матрица A: ");
                            A.ShowMatrix();
                            Console.WriteLine("Матрица B: ");
                            B.ShowMatrix();
                            Console.WriteLine("Матрица C: ");
                            C.ShowMatrix();
                        }
                        break;
                    case 5:
                        isWork = false;
                        break;
                }
            }
        }
    }
}
