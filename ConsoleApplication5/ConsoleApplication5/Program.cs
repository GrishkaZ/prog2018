using System;


namespace ConsoleApplication
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            int low, high, middle;
            low = 0;
            if (array == null)
                return -1;
            high = array.Length - 1;
            while (low <= high)
            {
                middle = (low + high) / 2;
                if (value < array[middle])
                    high = middle - 1;
                else if (value > array[middle])
                    low = middle + 1;
                else
                    return middle;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            TestNegativeNumbers();
            TestNonExistentElement();
            TestOneOfFive();
            TestRepeatElement();
            TestNullArray();
            TestBigArray();
            Console.ReadKey();
        }
        private static void TestNegativeNumbers()
        {

            //Тестирование поиска в отрицательных числах
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
        }
        private static void TestNonExistentElement()
        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента вернул корректный результат работает корректно");
        }
        private static void TestOneOfFive()
        {
            //Поиск одного элемента в массиве из 5 элементов
            int[] numbers = new[] { 5, 4, 3, 2, 8 };
            if (BinarySearch(numbers, 3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {5, 4, 3, 2, 8}");
            else
                Console.WriteLine("Поиск одного элемента в массиве из 5 элементов работает корректно");
        }

        private static void TestRepeatElement()
        {
            //Поиск элемента, повторяющегося несколько раз
            int[] array = new[] { 1, 5, 26, 10, 10, 10, 10, 10, 10, 10 };
            if (array[BinarySearch(array, 10)] != 10)           
                Console.WriteLine("! Поиск не нашёл число 30, которое повторяется в массиве несколько раз");           
            else            
                Console.WriteLine("Поиск элемента, повторяющегося несколько раз, работает корректно");           
        }
        private static void TestNullArray()
        {
            //Тестирование поиска отсутствующего элемента
            int[] Numbers = null;
            if (BinarySearch(Numbers, 1) != -1)
                Console.WriteLine("! Поиск нашёл число 1 в пустом массиве");
            else
                Console.WriteLine("Поиск в пустом массиве работает корректно");
        }
        private static void TestBigArray()
        {
            //Тестирование поиска отсутствующего элемента
            int[] array = new int[10001];
            //Random random = new Random();
            for (int i = 0; i < array.Length; i++)

                array[i] = i;
            if (BinarySearch(array, 1) == -1)
                Console.WriteLine("! Поиск в большом массиве не работает");
            else
                Console.WriteLine("Поиск в массиве из 1001 работает корректно");
        }
    }
}