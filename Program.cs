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
            int[] test1 = new int[5] { 1, 5, 9, 10, 5 };
            Console.Write("Входной массив Test1:");
            WriteMass(test1);
            int Test1Count = Algoritm_Balance(ref test1);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test1);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test1Count}");
            Console.WriteLine(" "); 

            int[] test2 = new int[3] { 1, 2, 3 };
            Console.Write("Входной массив Test2:");
            WriteMass(test2);
            int Test2Count = Algoritm_Balance(ref test2);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test2);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test2Count}");
            Console.WriteLine(" "); 

            int[] test3 = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 0 };
            Console.Write("Входной массив Test3:");
            WriteMass(test3);
            int Test3Count = Algoritm_Balance(ref test3);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test3);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test3Count}");
            Console.WriteLine(" "); 

            int[] test4 = new int[5] { 8, 10, 2, 5, 5 };
            Console.Write("Входной массив Test4:");
            WriteMass(test4);
            int Test4Count = Algoritm_Balance(ref test4);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test4);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test4Count}");
            Console.WriteLine(" ");

            int[] test5 = new int[5] { 0, 3, 10, 6, 1 };
            Console.Write("Входной массив Test5:");
            WriteMass(test5);
            int Test5Count = Algoritm_Balance(ref test5);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test5);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test5Count}");
            Console.WriteLine(" ");

            int[] test6 = new int[10] { 2, 7, 4, 2, 4, 10, 5, 7, 2, 7 };
            Console.Write("Входной массив Test6:");
            WriteMass(test6);
            int Test6Count = Algoritm_Balance(ref test6);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test6);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test6Count}");
            Console.WriteLine(" ");

            int[] test7 = new int[5] { 1, 3, 6, 9, 1 };
            Console.Write("Входной массив Test7:");
            WriteMass(test7);
            int Test7Count = Algoritm_Balance(ref test7);
            Console.WriteLine(" ");
            Console.Write("Выходной массив:");
            WriteMass(test7);
            Console.WriteLine(" ");
            Console.WriteLine($"Количество ходов: {Test7Count}");
            Console.WriteLine(" "); 

            Console.ReadKey();
        }


        static int Algoritm_Balance(ref int[] array)
        {
            int BalanceNumber;
            int buf=0;
            foreach(var z in array) { buf += z; }
            BalanceNumber = buf / array.Length;

            int Count=0;
            bool Done=false;
            int ArrayLenght = array.Length - 1;
            bool RF;
            int IndexMin = 0;
            while (!Done)
            {
                int Range;
                int max_Index = MaxElement(array);
                IndexMin = MinElementNearMax(array, out RF, out Range);

                //RF - Идти вперед или назад, относительно минимального элемента
                if (RF)
                {
                    int pos = max_Index;
                    if (pos == 0)
                    {
                        Count++;
                        array[pos]--;
                        array[ArrayLenght]++;
                        pos = ArrayLenght;
                    }
                    else
                    {
                        Count++;
                        array[pos]--;
                        array[pos - 1]++;
                        pos--;
                    }
                }
                else
                {
                    int pos = max_Index;
                    if (pos == ArrayLenght)
                    {
                        Count++;
                        array[ArrayLenght]--;
                        array[0]++;
                        pos = 0;
                    }
                    else
                    {
                        Count++;
                        array[pos]--;
                        array[pos + 1]++;
                        pos++;
                    }
                }

                foreach (var z in array)
                {
                    if (z != BalanceNumber)
                    {
                        Done = false;
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

        //Index
        static int MinElement(int[] array)
        {
            int Index = 0;
            int minElement = array[0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                    Index = i;
                }
            }
            return Index;
        }

        //Index
        static int MaxElement(int[] array)
        {
            int Index = 0;
            int minElement = array[0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (minElement < array[i])
                {
                    minElement = array[i];
                    Index = i;
                }
            }
            return Index;
        }

        //Index
        static int MinElementNearMax(int[] array, out bool RF, out int Range)
        {
            int min_Index = MinElement(array);
            int max_Index = MaxElement(array);
            int Index = min_Index;
            int minElement = array[min_Index];
            //
            int RangeFoward = Math.Abs(max_Index - min_Index);
            int RangeBack = Math.Min(min_Index, max_Index) + (array.GetLength(0) - Math.Max(min_Index, max_Index));
            int RangeNear = Math.Min(RangeBack, RangeFoward);
            //
            int RangeFowardBuf;
            int RangeBackBuf;
            int RangeNearBuf;
            //
            for (int i = 0; i < array.Length - 1; i++)
            {
                if(array[i] == minElement)
                {
                    RangeFowardBuf = Math.Abs(max_Index - i);
                    RangeBackBuf = Math.Min(i, max_Index) + (array.GetLength(0) - Math.Max(i, max_Index));
                    RangeNearBuf = Math.Min(RangeBack, RangeFoward);

                    if(RangeNear > RangeNearBuf)
                    {
                        Index = i;
                        RangeFoward = Math.Abs(max_Index - i);
                        RangeBack = Math.Min(i, max_Index) + (array.GetLength(0) - Math.Max(i, max_Index));
                        RangeNear = RangeNearBuf;
                    }
                }
            }

            Range = RangeNear;
            //Если индекс минимального числа больше индекса максимального перевернуть.
            if(Index > max_Index)
            {
                RF = RangeBack > RangeFoward ? false : true;
            }
            else
            {
                RF = RangeBack > RangeFoward ? true : false;
            }
            

            return Index;
        }

    }
}
