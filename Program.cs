using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ELaboTek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test1 = new int[5] { 1, 5, 9, 10, 5};
            Console.Write("Входной массив Test1:");
            WriteMass(test1);
            int Test1Count = Algoritm_Balance(ref test1);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test1);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test1Count}");
            Console.WriteLine(" "); Console.WriteLine(" ");

            int[] test2 = new int[3] { 1,2,3};
            Console.Write("Входной массив Test2:");
            WriteMass(test2);
            int Test2Count = Algoritm_Balance(ref test2);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test2);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test2Count}");
            Console.WriteLine(" "); Console.WriteLine(" ");

            int[] test3 = new int[10] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2 };
            Console.Write("Входной массив Test3:");
            WriteMass(test3);
            int Test3Count = Algoritm_Balance(ref test3);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test3);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test3Count}");
            Console.WriteLine(" "); Console.WriteLine(" ");

            int[] test4 = new int[5] { 8, 10, 2, 5, 5 };
            Console.Write("Входной массив Test4:");
            WriteMass(test4);
            int Test4Count = Algoritm_Balance(ref test4);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test4);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test4Count}");
            Console.WriteLine(" "); Console.WriteLine(" ");

            Console.ReadKey();
        }


        static int Algoritm_Balance(ref int[] Mass)
        {
            int BalanceNumber;
            int buf=0;
            foreach(var z in Mass) { buf += z; }
            BalanceNumber = buf / Mass.Length;

            int Count=0;
            bool Done=false;
            while (!Done)
            {
                for (int i = 0; i < Mass.Length; i++)
                {
                    while (Mass[i] > BalanceNumber)
                    {
                        if (i != 0 && Mass[i - 1] < BalanceNumber)
                        {
                            while (Mass[i] > BalanceNumber)
                            {
                                Count++;
                                Mass[i]--;
                                Mass[i - 1]++;
                            }
                            break;
                        }
                        else if (i != Mass.Length - 1 && Mass[i + 1] < BalanceNumber)
                        {
                            while(Mass[i] > BalanceNumber)
                            {
                                Count++;
                                Mass[i]--;
                                Mass[i + 1]++;
                            }
                        }
                        else if(i == Mass.Length -1 && Mass[0] < BalanceNumber)
                        {
                            while (Mass[i] > BalanceNumber)
                            {
                                Count++;
                                Mass[i]--;
                                Mass[0]++;
                            }
                        }
                        else if(i==0 && Mass[Mass.Length-1] < BalanceNumber)
                        {
                            while(Mass[i] > BalanceNumber)
                            {
                                Count++;
                                Mass[0]--;
                                Mass[Mass.Length - 1]++;
                            }
                        }
                    }
                }

                foreach (var z in Mass)
                {
                    if (z != BalanceNumber)
                    {
                        break;
                    }
                    else
                    {
                        Done = true;

                    }
                }

            }

            return Count;
        }

        static void WriteMass(int[] Mass)
        {
            Console.Write("[");
            foreach(var z in Mass)
            {
                Console.Write(z + " ");
            }
            Console.Write("]");
        }
    }
}
