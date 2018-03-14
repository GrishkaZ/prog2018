using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuickSort
{
    public class QuickSorting
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            QuickSort(array, 0, array.Length - 1);
            Console.ReadKey();
        }

        public static void QuickSort(int[] array, int first, int last)
        {
            if (array.Length != 0)
            {
                int p = array[(last - first) / 2 + first];
                int temp;
                int i = first, j = last;
                while (i <= j)
                {
                    while (array[i] < p && i <= last) ++i;
                    while (array[j] > p && j >= first) --j;
                    if (i <= j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        ++i; --j;
                    }
                }
                if (j > first) QuickSort(array, first, j);
                if (i < last) QuickSort(array, i, last);
            }
            else Console.WriteLine("массив пустой");
        }
    }
}

