using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*
Найти определитель матрицы А. Входные данные: целое положительное
число n, произвольная матрица А размерности n х n. Решить задачу
двумя способами: 1) количество потоков является входным параметром, при
этом размерность матриц может быть не кратна количеству потоков; 2) количество
потоков заранее неизвестно и не является параметром задачи. 
 */
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите размерность матирицы: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = n;

            Console.WriteLine("");
            int[,] A = new int[n, m];
            Random rn = new Random();
            Console.WriteLine("Матрица А: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    A[i, j] = rn.Next(11) - 5;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(String.Format("{0,3}", A[i, j]));
                Console.WriteLine();
            }

            int opredelitel = 0;
            if (n==2) {
                opredelitel = A[0, 0] * A[1, 1] - A[0,1] * A[1,0];
                Console.Write("Определитель матрицы А равен ");
                Console.Write(String.Format("{0,3}",opredelitel));           
            }
            if (n == 3)
            {
                opredelitel = A[0, 0] * A[1, 1] * A[2,2] + 
                              A[0, 1] * A[1, 2] * A[2, 0] +
                              A[0, 2] * A[1, 0] * A[2, 1] -
                              A[0, 0] * A[1, 2] * A[2, 1] -
                              A[0, 1] * A[1, 0] * A[2, 2] -
                              A[0, 2] * A[1, 1] * A[2, 0]
                              ;
                Console.Write("Определитель матрицы А равен ");
                Console.Write(String.Format("{0,3}", opredelitel));
            }
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            Console.ReadLine();

        }
        public static void Count()
        {

        }

    }
}
